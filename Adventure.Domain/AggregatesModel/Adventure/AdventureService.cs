using Adventure.Domain.AggregatesModel.Adventure;
using Adventure.Domain.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.AggregatesModel
{
    public class AdventureService : IAdventureService
    {
        private readonly ILogger<AdventureService> _logger;
        private readonly IAdventureRepository _adventureRepository;


        public AdventureService(ILogger<AdventureService> logger, IAdventureRepository adventureRepository) 
        {
            _logger = logger;
            _adventureRepository = adventureRepository;
        }

        public async Task<AdventureDecisionTreeDTO> AdventureDecisionTree() 
        {
            _logger.LogDebug("AdventureService -  AdventureDecisionTree was called");

            return await _adventureRepository.AdventureDecisionTree();
        }

        public async Task<AdventureDTO> AdventureById(int id)
        {
            _logger.LogDebug("AdventureService -  AdventureById was called");

            return await _adventureRepository.AdventureById(id);
        }
    }
}
