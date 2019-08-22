using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Client
    {
        public Client()
        {
            Inconsistency = new HashSet<Inconsistency>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int ClientId { get; set; }
        public string GroupEmpresarial { get; set; }
        public string RegistryTributario { get; set; }
        public int RegistryTributarioTypeId { get; set; }
        public string Address { get; set; }
        public string WebPage { get; set; }
        public string BussinesActivity { get; set; }
        public int ProductLineId { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
        public string Value { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public decimal? Phone { get; set; }
        public string Industry { get; set; }
        public int SegmentoId { get; set; }
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
        public virtual IndustryType IndustryType { get; set; }
        public virtual Country Market { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        public virtual RegistryTributarioType RegistryTributarioType { get; set; }
        public virtual Segment Segmento { get; set; }
        public virtual ICollection<Inconsistency> Inconsistency { get; set; }
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
