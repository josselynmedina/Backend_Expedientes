using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Rol
    {
        public Rol()
        {
            UserRol = new HashSet<UserRol>();
        }

        public int RolId { get; set; }
        public string RolDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRol { get; set; }
    }
}
