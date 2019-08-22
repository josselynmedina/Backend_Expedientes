using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Inconsistency
    {
        public int InconsistencyId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaRecepcionDocumento { get; set; }
        public int ClientId { get; set; }
        public string HojaRuta { get; set; }
        public int ProveedorId { get; set; }
        public int DocumentId { get; set; }
        public string DocumentNumber { get; set; }
        public int CategoryId { get; set; }
        public string Comentario { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Category Category { get; set; }
        public virtual Client Client { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual Document Document { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
