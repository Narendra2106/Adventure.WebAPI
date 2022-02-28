using Adventure.Domain.AggregatesModel.Adventure;
using Adventure.Domain.DTO;
using Adventure.Domain.SeedWork.Enum;
using Adventure.Infrastructure.AdventureContext;
using Adventure.Infrastructure.Hepler;
using Adventure.Infrastructure.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Repository
{
    public class AdventureRepository : RepositoryBase<Adventure.Infrastructure.AdventureContext.Adventure>, IAdventureRepository
    {

        private readonly ILogger<AdventureRepository> _logger;


        public AdventureRepository(PlayerAdventureContext applicationContext, ILogger<AdventureRepository> logger)
            : base(applicationContext)
        {
            _logger = logger;
        }

        public async Task<AdventureDTO> AdventureById(int id)
        {
            _logger.LogDebug("AdventureRepository -  AdventureById was called");


            Adventure.Infrastructure.AdventureContext.Adventure result = new Adventure.Infrastructure.AdventureContext.Adventure();

            if (id > 0)
                result = await _applicationContext.Adventures.SingleOrDefaultAsync(x => x.AdventureId == id);
            else
                result = await FirstAdventure();

            return result?.ToAdventure();
        }

        public async Task<AdventureDecisionTreeDTO> AdventureDecisionTree()
        {
            _logger.LogDebug("AdventureRepository -  AdventureDecisionTree was called");


            void FillCteResult(AdventureDecisionTreeDTO node, Adventure.Infrastructure.AdventureContext.Adventure currentEntity, Queue<Adventure.Infrastructure.AdventureContext.Adventure> entities)
            {
                if (currentEntity.IfYesNextQuestionId.HasValue || currentEntity.IfNoNextQuestionId.HasValue)
                    node.Children = new List<AdventureDecisionTreeDTO>();
                else
                {
                    return;
                }

                Adventure.Infrastructure.AdventureContext.Adventure yesAdenture = null;
                AdventureDecisionTreeDTO yesNextQuestion = null;

                Adventure.Infrastructure.AdventureContext.Adventure noAdventure = null;
                AdventureDecisionTreeDTO noNextQuestion = null;

                if (currentEntity.IfYesNextQuestionId.HasValue)
                {
                    yesAdenture = entities.Dequeue();
                    yesNextQuestion = yesAdenture.ToQuestionTreeNode(YesNoAnswer.Yes);
                    node.Children.Add(yesNextQuestion);
                }

                if (currentEntity.IfNoNextQuestionId.HasValue)
                {
                    noAdventure = entities.Dequeue();
                    noNextQuestion = noAdventure.ToQuestionTreeNode(YesNoAnswer.No);
                    node.Children.Add(noNextQuestion);
                }

                if (noNextQuestion != null)
                    FillCteResult(noNextQuestion, noAdventure, entities);

                if (yesAdenture != null)
                    FillCteResult(yesNextQuestion, yesAdenture, entities);
            }

            var firstQuestion = await FirstAdventure();
            if (firstQuestion == null)
                return null;



            var query = _applicationContext.Adventures.FromSqlRaw("exec GetAdventureTree {0}", firstQuestion.AdventureId).AsNoTracking();

            var entities = new Queue<Adventure.Infrastructure.AdventureContext.Adventure>(query);

            //var query = await _applicationContext.Adventures.ToListAsync();
            //var entities = new Queue<Adventure.Infrastructure.AdventureContext.Adventure>(query);

            var root = entities.Dequeue();
            var result = root.ToQuestionTreeNode(null);

            FillCteResult(result, root, entities);

            return result;
        }

        private async Task<Adventure.Infrastructure.AdventureContext.Adventure> FirstAdventure()
        {
            var allAdventure =  await _applicationContext.Adventures.ToListAsync();

            return allAdventure
               .Where(ad => !allAdventure.Any(x => x.IfYesNextQuestionId == ad.AdventureId))
               .SingleOrDefault(ad => !allAdventure.Any(x => x.IfNoNextQuestionId == ad.AdventureId));

        }
        

    }

    }
