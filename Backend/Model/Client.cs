using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Client
    {
        public Client()
        {
            Contact = new HashSet<Contact>();
            Inconsistency = new HashSet<Inconsistency>();
            Proveedor = new HashSet<Proveedor>();
            SapCode = new HashSet<SapCode>();
            SolCredit = new HashSet<SolCredit>();
        }

        public int ClientId { get; set; }
        public string EmpresarialGroup { get; set; }
        public string RegistryTributario { get; set; }
        public int FiscalTypeId { get; set; }
        public string Address { get; set; }
        public string WebPage { get; set; }
        public string BussinesActivity { get; set; }
        public int ProductLineId { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
        public string Valores { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public decimal? Phone { get; set; }
        public string Industry { get; set; }
        public int SegmentId { get; set; }
        public int IndustryTypeId { get; set; }
        public string Rse { get; set; }
        public string Marcas { get; set; }
        public int MarketId { get; set; }
        public int BillingCountryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual Country BillingCountry { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual FiscalType FiscalType { get; set; }
        public virtual IndustryType IndustryType { get; set; }
        public virtual Country Market { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        public virtual Segment Segment { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Inconsistency> Inconsistency { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        public virtual ICollection<SapCode> SapCode { get; set; }
        public virtual ICollection<SolCredit> SolCredit { get; set; }
    }
}
