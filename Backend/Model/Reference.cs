using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Reference
    {
        public int RefrenceId { get; set; }
        public int SolCreditId { get; set; }
        public string BancName { get; set; }
        public string AccountNumbre { get; set; }
        public decimal? Aantiguedad { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
        public string Adetalle { get; set; }
        public string ComercialName { get; set; }
        public string RelationType { get; set; }
        public decimal? Cantiguedad { get; set; }
        public decimal? Calification { get; set; }
        public string FormaPago { get; set; }
        public string Cdetalle { get; set; }
        public string Dictamen { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
