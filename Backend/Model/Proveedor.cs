﻿using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Inconsistency = new HashSet<Inconsistency>();
        }

        public int ProveedorId { get; set; }
        public string ProveedorDescription { get; set; }
        public string IdentificadorFiscal { get; set; }
        public int TypeFiscalId { get; set; }
        public int PersonGroupId { get; set; }
        public int ClientId { get; set; }
        public int SegmentId { get; set; }
        public int CountryId { get; set; }
        public int OperationCountryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual Country OperationCountry { get; set; }
        public virtual PersonGroup PersonGroup { get; set; }
        public virtual Segment Segment { get; set; }
        public virtual FiscalType TypeFiscal { get; set; }
        public virtual ICollection<Inconsistency> Inconsistency { get; set; }
    }
}
