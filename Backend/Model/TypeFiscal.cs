using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class TypeFiscal
    {
        public TypeFiscal()
        {
            Proveedor = new HashSet<Proveedor>();
        }

        public int TypeFiscalId { get; set; }
        public string TypeFiscalDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
