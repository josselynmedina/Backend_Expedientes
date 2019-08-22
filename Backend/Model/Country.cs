using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class Country
    {
        public Country()
        {
            ClientBillingCountry = new HashSet<Client>();
            ClientCountry = new HashSet<Client>();
            ClientMarket = new HashSet<Client>();
            CountryCity = new HashSet<CountryCity>();
            ProveedorCountry = new HashSet<Proveedor>();
            ProveedorOperationCountryNavigation = new HashSet<Proveedor>();
        }

        public int CountryId { get; set; }
        public string CountryDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Client> ClientBillingCountry { get; set; }
        public virtual ICollection<Client> ClientCountry { get; set; }
        public virtual ICollection<Client> ClientMarket { get; set; }
        public virtual ICollection<CountryCity> CountryCity { get; set; }
        public virtual ICollection<Proveedor> ProveedorCountry { get; set; }
        public virtual ICollection<Proveedor> ProveedorOperationCountryNavigation { get; set; }
    }
}
