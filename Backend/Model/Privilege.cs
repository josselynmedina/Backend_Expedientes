using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Privilege
    {
        public int PrivilegeId { get; set; }
        public string PrivilegeDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
