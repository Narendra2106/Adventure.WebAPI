using Adventure.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.AggregatesModel
{
    public interface IAdventureService
    {
        Task<AdventureDecisionTreeDTO> AdventureDecisionTree();

        Task<AdventureDTO> AdventureById(int id);

    }
}
