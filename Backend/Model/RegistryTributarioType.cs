using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class RegistryTributarioType
    {
        public RegistryTributarioType()
        {
            Client = new HashSet<Client>();
        }

        public int RegistryTributarioTypeId { get; set; }
        public string RegistryTributarioTypeDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}
