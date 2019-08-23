using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class SolCredit
    {
        public int CreditId { get; set; }
        public int ClientId { get; set; }
        public string TramitesMensualesEsperados { get; set; }
        public string ProyeccionMensual { get; set; }
        public string ProyeccionVolumenMensualF { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Client Client { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
