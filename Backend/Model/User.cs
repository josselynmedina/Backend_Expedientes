using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class User
    {
        public User()
        {
            CityCreatedByNavigation = new HashSet<City>();
            CityModifiedByNavigation = new HashSet<City>();
            ClientCreatedByNavigation = new HashSet<Client>();
            ClientModifiedByNavigation = new HashSet<Client>();
            ContactCreatedByNavigation = new HashSet<Contact>();
            ContactModifiedByNavigation = new HashSet<Contact>();
            CountryCityCreatedByNavigation = new HashSet<CountryCity>();
            CountryCityModifiedByNavigation = new HashSet<CountryCity>();
            CountryCreatedByNavigation = new HashSet<Country>();
            CountryModifiedByNavigation = new HashSet<Country>();
            DocumentCreatedByNavigation = new HashSet<Document>();
            DocumentModifiedByNavigation = new HashSet<Document>();
            FiscalTypeCreatedByNavigation = new HashSet<FiscalType>();
            FiscalTypeModifiedByNavigation = new HashSet<FiscalType>();
            InconsistencyCreatedByNavigation = new HashSet<Inconsistency>();
            InconsistencyModifiedByNavigation = new HashSet<Inconsistency>();
            IndustryTypeCreatedByNavigation = new HashSet<IndustryType>();
            IndustryTypeModifiedByNavigation = new HashSet<IndustryType>();
            InverseCreatedByNavigation = new HashSet<User>();
            InverseModifiedByNavigation = new HashSet<User>();
            PersonGroupCreatedByNavigation = new HashSet<PersonGroup>();
            PersonGroupModifiedByNavigation = new HashSet<PersonGroup>();
            PrivilegeCreatedByNavigation = new HashSet<Privilege>();
            PrivilegeModifiedByNavigation = new HashSet<Privilege>();
            ProductLineCreatedByNavigation = new HashSet<ProductLine>();
            ProductLineModifiedByNavigation = new HashSet<ProductLine>();
            ProveedorCreatedByNavigation = new HashSet<Proveedor>();
            ProveedorModifiedByNavigation = new HashSet<Proveedor>();
            ReferenceCreatedByNavigation = new HashSet<Reference>();
            ReferenceModifiedByNavigation = new HashSet<Reference>();
            RolCreatedByNavigation = new HashSet<Rol>();
            RolModifiedByNavigation = new HashSet<Rol>();
            RolPrivilegeCreatedByNavigation = new HashSet<RolPrivilege>();
            RolPrivilegeModifiedByNavigation = new HashSet<RolPrivilege>();
            SapCodeCreatedByNavigation = new HashSet<SapCode>();
            SapCodeModifiedByNavigation = new HashSet<SapCode>();
            SegmentCreatedByNavigation = new HashSet<Segment>();
            SegmentModifiedByNavigation = new HashSet<Segment>();
            SolCreditCreatedByNavigation = new HashSet<SolCredit>();
            SolCreditModifiedByNavigation = new HashSet<SolCredit>();
            UserRolCreatedByNavigation = new HashSet<UserRol>();
            UserRolModifiedByNavigation = new HashSet<UserRol>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string Email { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<City> CityCreatedByNavigation { get; set; }
        public virtual ICollection<City> CityModifiedByNavigation { get; set; }
        public virtual ICollection<Client> ClientCreatedByNavigation { get; set; }
        public virtual ICollection<Client> ClientModifiedByNavigation { get; set; }
        public virtual ICollection<Contact> ContactCreatedByNavigation { get; set; }
        public virtual ICollection<Contact> ContactModifiedByNavigation { get; set; }
        public virtual ICollection<CountryCity> CountryCityCreatedByNavigation { get; set; }
        public virtual ICollection<CountryCity> CountryCityModifiedByNavigation { get; set; }
        public virtual ICollection<Country> CountryCreatedByNavigation { get; set; }
        public virtual ICollection<Country> CountryModifiedByNavigation { get; set; }
        public virtual ICollection<Document> DocumentCreatedByNavigation { get; set; }
        public virtual ICollection<Document> DocumentModifiedByNavigation { get; set; }
        public virtual ICollection<FiscalType> FiscalTypeCreatedByNavigation { get; set; }
        public virtual ICollection<FiscalType> FiscalTypeModifiedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> InconsistencyCreatedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> InconsistencyModifiedByNavigation { get; set; }
        public virtual ICollection<IndustryType> IndustryTypeCreatedByNavigation { get; set; }
        public virtual ICollection<IndustryType> IndustryTypeModifiedByNavigation { get; set; }
        public virtual ICollection<User> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<User> InverseModifiedByNavigation { get; set; }
        public virtual ICollection<PersonGroup> PersonGroupCreatedByNavigation { get; set; }
        public virtual ICollection<PersonGroup> PersonGroupModifiedByNavigation { get; set; }
        public virtual ICollection<Privilege> PrivilegeCreatedByNavigation { get; set; }
        public virtual ICollection<Privilege> PrivilegeModifiedByNavigation { get; set; }
        public virtual ICollection<ProductLine> ProductLineCreatedByNavigation { get; set; }
        public virtual ICollection<ProductLine> ProductLineModifiedByNavigation { get; set; }
        public virtual ICollection<Proveedor> ProveedorCreatedByNavigation { get; set; }
        public virtual ICollection<Proveedor> ProveedorModifiedByNavigation { get; set; }
        public virtual ICollection<Reference> ReferenceCreatedByNavigation { get; set; }
        public virtual ICollection<Reference> ReferenceModifiedByNavigation { get; set; }
        public virtual ICollection<Rol> RolCreatedByNavigation { get; set; }
        public virtual ICollection<Rol> RolModifiedByNavigation { get; set; }
        public virtual ICollection<RolPrivilege> RolPrivilegeCreatedByNavigation { get; set; }
        public virtual ICollection<RolPrivilege> RolPrivilegeModifiedByNavigation { get; set; }
        public virtual ICollection<SapCode> SapCodeCreatedByNavigation { get; set; }
        public virtual ICollection<SapCode> SapCodeModifiedByNavigation { get; set; }
        public virtual ICollection<Segment> SegmentCreatedByNavigation { get; set; }
        public virtual ICollection<Segment> SegmentModifiedByNavigation { get; set; }
        public virtual ICollection<SolCredit> SolCreditCreatedByNavigation { get; set; }
        public virtual ICollection<SolCredit> SolCreditModifiedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRolCreatedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRolModifiedByNavigation { get; set; }
    }
}
