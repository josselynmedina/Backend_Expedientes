using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public string ContactName { get; set; }
        public string ContactPosition { get; set; }
        public string ContactEmail { get; set; }
        public decimal? ContactPhone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Client Client { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
