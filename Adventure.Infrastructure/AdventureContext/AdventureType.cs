using System;
using System.Collections.Generic;

#nullable disable

namespace Adventure.Infrastructure.AdventureContext
{
    public partial class AdventureType
    {
        public AdventureType()
        {
            Adventures = new HashSet<Adventure>();
        }

        public int AdventureTypeId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; } = "System";
        public DateTime CreatedOn { get; set; } =  DateTime.UtcNow;
        public string LastUpdatedBy { get; set; } =  "System";
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Adventure> Adventures { get; set; }
    }
}
