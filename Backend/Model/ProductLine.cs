using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class ProductLine
    {
        public ProductLine()
        {
            Client = new HashSet<Client>();
        }

        public int ProductLineId { get; set; }
        public string ProductLineDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}
