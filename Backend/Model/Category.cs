using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Category
    {
        public Category()
        {
            Inconsistency = new HashSet<Inconsistency>();
        }

        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> Inconsistency { get; set; }
    }
}
