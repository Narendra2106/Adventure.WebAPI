using Adventure.Domain.AggregatesModel.AdventureType;
using Adventure.Domain.DTO;
using Adventure.Infrastructure.AdventureContext;
using Adventure.Infrastructure.RepositoryBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Repository
{
   public class AdventureTypeRepository: RepositoryBase<AdventureType>, IAdventureTypeRepository
    {
        private readonly ILogger<AdventureTypeRepository> _logger;


        public AdventureTypeRepository(PlayerAdventureContext applicationContext, ILogger<AdventureTypeRepository> logger)
            : base(applicationContext)
        {
            _logger = logger;
        }

        public async Task<AdventureTypeDTO> CreateAdventureType(AdventureTypeDTO adventureTypeDTO) 
        {
            _logger.LogDebug("AdventureTypeRepository -  CreateAdventureType was called");

            AdventureType adType = new AdventureType(); //  We can use mapper as well...
            adType.Name = adventureTypeDTO.Name;
           await _applicationContext.AddAsync<AdventureType>(adType);

            return adventureTypeDTO;
        }
    }
}
