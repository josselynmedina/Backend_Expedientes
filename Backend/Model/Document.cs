using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Document
    {
        public Document()
        {
            Inconsistency = new HashSet<Inconsistency>();
        }

        public int DocumentId { get; set; }
        public string DocumentDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> Inconsistency { get; set; }
    }
}
