using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class RolPrivilege
    {
        public int RolId { get; set; }
        public int PrivilegeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
