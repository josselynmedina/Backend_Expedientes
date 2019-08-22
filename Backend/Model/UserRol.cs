using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class UserRol
    {
        public int UserId { get; set; }
        public int RolId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual User User { get; set; }
    }
}
