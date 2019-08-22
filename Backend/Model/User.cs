using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class User
    {
        public User()
        {
            CategoryCreatedByNavigation = new HashSet<Category>();
            CategoryModifiedByNavigation = new HashSet<Category>();
            CityCreatedByNavigation = new HashSet<City>();
            CityModifiedByNavigation = new HashSet<City>();
            CountryCityCreatedByNavigation = new HashSet<CountryCity>();
            CountryCityModifiedByNavigation = new HashSet<CountryCity>();
            CountryCreatedByNavigation = new HashSet<Country>();
            CountryModifiedByNavigation = new HashSet<Country>();
            DocumentCreatedByNavigation = new HashSet<Document>();
            DocumentModifiedByNavigation = new HashSet<Document>();
            GroupPeopleCreatedByNavigation = new HashSet<GroupPeople>();
            GroupPeopleModifiedByNavigation = new HashSet<GroupPeople>();
            InconsistencyCreatedByNavigation = new HashSet<Inconsistency>();
            InconsistencyModifiedByNavigation = new HashSet<Inconsistency>();
            IndustryTypeCreatedByNavigation = new HashSet<IndustryType>();
            IndustryTypeModifiedByNavigation = new HashSet<IndustryType>();
            InverseCreatedByNavigation = new HashSet<User>();
            InverseModifiedByNavigation = new HashSet<User>();
            PrivilegeCreatedByNavigation = new HashSet<Privilege>();
            PrivilegeModifiedByNavigation = new HashSet<Privilege>();
            ProductLineCreatedByNavigation = new HashSet<ProductLine>();
            ProductLineModifiedByNavigation = new HashSet<ProductLine>();
            ProveedorCreatedByNavigation = new HashSet<Proveedor>();
            ProveedorModifiedByNavigation = new HashSet<Proveedor>();
            RegistryTributarioTypeCreatedByNavigation = new HashSet<RegistryTributarioType>();
            RegistryTributarioTypeModifiedByNavigation = new HashSet<RegistryTributarioType>();
            RolCreatedByNavigation = new HashSet<Rol>();
            RolModifiedByNavigation = new HashSet<Rol>();
            RolPrivilegeCreatedByNavigation = new HashSet<RolPrivilege>();
            RolPrivilegeModifiedByNavigation = new HashSet<RolPrivilege>();
            SegmentCreatedByNavigation = new HashSet<Segment>();
            SegmentModifiedByNavigation = new HashSet<Segment>();
            TypeFiscalCreatedByNavigation = new HashSet<TypeFiscal>();
            TypeFiscalModifiedByNavigation = new HashSet<TypeFiscal>();
            UserRolCreatedByNavigation = new HashSet<UserRol>();
            UserRolModifiedByNavigation = new HashSet<UserRol>();
            UserRolUser = new HashSet<UserRol>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Category> CategoryCreatedByNavigation { get; set; }
        public virtual ICollection<Category> CategoryModifiedByNavigation { get; set; }
        public virtual ICollection<City> CityCreatedByNavigation { get; set; }
        public virtual ICollection<City> CityModifiedByNavigation { get; set; }
        public virtual ICollection<CountryCity> CountryCityCreatedByNavigation { get; set; }
        public virtual ICollection<CountryCity> CountryCityModifiedByNavigation { get; set; }
        public virtual ICollection<Country> CountryCreatedByNavigation { get; set; }
        public virtual ICollection<Country> CountryModifiedByNavigation { get; set; }
        public virtual ICollection<Document> DocumentCreatedByNavigation { get; set; }
        public virtual ICollection<Document> DocumentModifiedByNavigation { get; set; }
        public virtual ICollection<GroupPeople> GroupPeopleCreatedByNavigation { get; set; }
        public virtual ICollection<GroupPeople> GroupPeopleModifiedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> InconsistencyCreatedByNavigation { get; set; }
        public virtual ICollection<Inconsistency> InconsistencyModifiedByNavigation { get; set; }
        public virtual ICollection<IndustryType> IndustryTypeCreatedByNavigation { get; set; }
        public virtual ICollection<IndustryType> IndustryTypeModifiedByNavigation { get; set; }
        public virtual ICollection<User> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<User> InverseModifiedByNavigation { get; set; }
        public virtual ICollection<Privilege> PrivilegeCreatedByNavigation { get; set; }
        public virtual ICollection<Privilege> PrivilegeModifiedByNavigation { get; set; }
        public virtual ICollection<ProductLine> ProductLineCreatedByNavigation { get; set; }
        public virtual ICollection<ProductLine> ProductLineModifiedByNavigation { get; set; }
        public virtual ICollection<Proveedor> ProveedorCreatedByNavigation { get; set; }
        public virtual ICollection<Proveedor> ProveedorModifiedByNavigation { get; set; }
        public virtual ICollection<RegistryTributarioType> RegistryTributarioTypeCreatedByNavigation { get; set; }
        public virtual ICollection<RegistryTributarioType> RegistryTributarioTypeModifiedByNavigation { get; set; }
        public virtual ICollection<Rol> RolCreatedByNavigation { get; set; }
        public virtual ICollection<Rol> RolModifiedByNavigation { get; set; }
        public virtual ICollection<RolPrivilege> RolPrivilegeCreatedByNavigation { get; set; }
        public virtual ICollection<RolPrivilege> RolPrivilegeModifiedByNavigation { get; set; }
        public virtual ICollection<Segment> SegmentCreatedByNavigation { get; set; }
        public virtual ICollection<Segment> SegmentModifiedByNavigation { get; set; }
        public virtual ICollection<TypeFiscal> TypeFiscalCreatedByNavigation { get; set; }
        public virtual ICollection<TypeFiscal> TypeFiscalModifiedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRolCreatedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRolModifiedByNavigation { get; set; }
        public virtual ICollection<UserRol> UserRolUser { get; set; }
    }
}
