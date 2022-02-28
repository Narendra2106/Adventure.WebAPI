using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Adventure.Infrastructure.AdventureContext
{
    public partial class Adventure
    {
        public int AdventureId { get; set; }
        public int AdventureTypeId { get; set; }
        public string Question { get; set; }
        public int? IfYesNextQuestionId { get; set; }
        [NotMapped]
        public Adventure IfYesNextQuestion { get; set; }
        public int? IfNoNextQuestionId { get; set; }
        [NotMapped]
        public Adventure IfNoNextQuestion { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual AdventureType AdventureType { get; set; }

    
    }
}
