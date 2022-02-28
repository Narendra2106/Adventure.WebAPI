using Adventure.Domain.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.AggregatesModel.AdventureType
{
    public class AdventureTypeService : IAdventureTypeService
    {
        private readonly ILogger<AdventureTypeService> _logger;
        private readonly IAdventureTypeRepository _adventureTypeRepository;


        public AdventureTypeService(ILogger<AdventureTypeService> logger, IAdventureTypeRepository adventureTypeRepository)
        {
            _logger = logger;
            _adventureTypeRepository = adventureTypeRepository;
        }

        public Task<AdventureTypeDTO> CreateAdventureType(AdventureTypeDTO adventureTypeDTO) 
        {
            _logger.LogDebug("AdventureTypeService -  CreateAdventureType was called");

            return _adventureTypeRepository.CreateAdventureType(adventureTypeDTO);
        }
    }
}
