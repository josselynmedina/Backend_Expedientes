using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class GroupPeople
    {
        public GroupPeople()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        public int GroupPeopleId { get; set; }
        public string GroupPeopleDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
