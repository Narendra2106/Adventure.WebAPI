using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DTO
{
    public class AdventureDTO
    {
        public int AdventureId { get; set; }

        public string Question { get; set; }

        public int? IfYesNextQuestionId { get; set; }

        public int? IfNoNextQuestionId { get; set; }
    }
}
