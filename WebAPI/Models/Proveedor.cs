//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            this.Inconsistencies = new HashSet<Inconsistency>();
        }
    
        public string ProveedorId { get; set; }
        public string ProveedorDescription { get; set; }
        public string IdentificadorFiscal { get; set; }
        public string FiscalTypeId { get; set; }
        public string PersonGroupId { get; set; }
        public string ClientId { get; set; }
        public string SegmentId { get; set; }
        public string CountryId { get; set; }
        public string OperationCountry { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual FiscalType FiscalType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inconsistency> Inconsistencies { get; set; }
        public virtual PersonGroup PersonGroup { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Segment Segment { get; set; }
    }
}
