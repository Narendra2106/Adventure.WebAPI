using Adventure.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.AggregatesModel.AdventureType
{
    public interface IAdventureTypeService
    {
        Task<AdventureTypeDTO> CreateAdventureType(AdventureTypeDTO adventureTypeDTO);
    }
}
