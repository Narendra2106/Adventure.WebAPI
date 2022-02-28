using Adventure.Domain.SeedWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DTO
{
   public class AdventureDecisionTreeDTO
    {
        public int AdventureId { get; set; }

        public string Question { get; set; }

        public YesNoAnswer? Type { get; set; }

        public List<AdventureDecisionTreeDTO> Children { get; set; }
    }
}
