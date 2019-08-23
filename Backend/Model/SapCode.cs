using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class SapCode
    {
        public int SapCodeId { get; set; }
        public string SapCode1 { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Client Client { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
