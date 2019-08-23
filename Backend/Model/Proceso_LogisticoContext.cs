using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Model
{
    public partial class Proceso_LogisticoContext : DbContext
    {
        public Proceso_LogisticoContext()
        {
        }

        public Proceso_LogisticoContext(DbContextOptions<Proceso_LogisticoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryCity> CountryCity { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<FiscalType> FiscalType { get; set; }
        public virtual DbSet<Inconsistency> Inconsistency { get; set; }
        public virtual DbSet<IndustryType> IndustryType { get; set; }
        public virtual DbSet<PersonGroup> PersonGroup { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<ProductLine> ProductLine { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolPrivilege> RolPrivilege { get; set; }
        public virtual DbSet<SapCode> SapCode { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<SolCredit> SolCredit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRol> UserRol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-F3PHG0S;Database=Proceso_Logistico;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityDescription).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CityModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_ModifiedBy");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BussinesActivity).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.EmpresarialGroup).HasMaxLength(50);

                entity.Property(e => e.Industry).HasMaxLength(50);

                entity.Property(e => e.Marcas).HasMaxLength(100);

                entity.Property(e => e.Mision).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RegistryTributario).HasMaxLength(50);

                entity.Property(e => e.Rse)
                    .HasColumnName("RSE")
                    .HasMaxLength(50);

                entity.Property(e => e.Valores).HasMaxLength(100);

                entity.Property(e => e.Vision).HasMaxLength(100);

                entity.Property(e => e.WebPage).HasMaxLength(50);

                entity.HasOne(d => d.BillingCountry)
                    .WithMany(p => p.ClientBillingCountry)
                    .HasForeignKey(d => d.BillingCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Billingcountry");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ClientCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Country");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ClientCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_CreatedBy");

                entity.HasOne(d => d.FiscalType)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.FiscalTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_FiscalType");

                entity.HasOne(d => d.IndustryType)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IndustryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_IndustryType");

                entity.HasOne(d => d.Market)
                    .WithMany(p => p.ClientMarket)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Market");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ClientModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_ModifiedBy");

                entity.HasOne(d => d.ProductLine)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.ProductLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_ProductLine");

                entity.HasOne(d => d.Segment)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.SegmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Segment");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => new { e.ContactId, e.ClientId });

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPosition).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Client");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ContactCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ContactModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ModifiedBy");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryDescription).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CountryCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CountryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_ModifiedBy");
            });

            modelBuilder.Entity<CountryCity>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.CityId });

                entity.ToTable("Country_City");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CountryCityCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_City_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CountryCityModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_City_ModifiedBy");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DocumentDescription).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DocumentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.DocumentModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_ModifiedBy");
            });

            modelBuilder.Entity<FiscalType>(entity =>
            {
                entity.Property(e => e.FiscalTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FiscalTypeDescription).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FiscalTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FiscalType_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.FiscalTypeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FiscalType_ModifiedBy");
            });

            modelBuilder.Entity<Inconsistency>(entity =>
            {
                entity.Property(e => e.InconsistencyId).ValueGeneratedNever();

                entity.Property(e => e.Comentario).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRecepcion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.HojaRuta).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Inconsistency)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_Category");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Inconsistency)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_Client");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InconsistencyCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_CreatedBy");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Inconsistency)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_Document");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.InconsistencyModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_ModifiedBy");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Inconsistency)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inconsistency_Proveedor");
            });

            modelBuilder.Entity<IndustryType>(entity =>
            {
                entity.Property(e => e.IndustryTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IndustryTypeDescription).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.IndustryTypeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IndustryType_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.IndustryTypeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IndustryType_ModifiedBy");
            });

            modelBuilder.Entity<PersonGroup>(entity =>
            {
                entity.Property(e => e.PersonGroupId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PersonGroupDescription).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PersonGroupCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonGroup_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PersonGroupModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonGroup_ModifiedBy");
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.Property(e => e.PrivilegeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PrivilegeDescription).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PrivilegeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Privilege_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PrivilegeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Privilege_ModifiedBy");
            });

            modelBuilder.Entity<ProductLine>(entity =>
            {
                entity.Property(e => e.ProductLineId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProductLineDescription).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductLineCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductLine_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProductLineModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductLine_ModifiedBy");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.ProveedorId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IdentificadorFiscal).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProveedorDescription).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_Client");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ProveedorCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_Country");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProveedorCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProveedorModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_ModifiedBy");

                entity.HasOne(d => d.OperationCountry)
                    .WithMany(p => p.ProveedorOperationCountry)
                    .HasForeignKey(d => d.OperationCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_CountryO");

                entity.HasOne(d => d.PersonGroup)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.PersonGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_PersonGroup");

                entity.HasOne(d => d.Segment)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.SegmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_Segment");

                entity.HasOne(d => d.TypeFiscal)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.TypeFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_Fiscaltype");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.HasKey(e => new { e.RefrenceId, e.SolCreditId })
                    .HasName("PK_Reference_1");

                entity.Property(e => e.Aantiguedad)
                    .HasColumnName("AAntiguedad")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountNumbre).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Adetalle)
                    .HasColumnName("ADetalle")
                    .HasMaxLength(50);

                entity.Property(e => e.BancName).HasMaxLength(50);

                entity.Property(e => e.Calification).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantiguedad)
                    .HasColumnName("CAntiguedad")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cdetalle)
                    .HasColumnName("CDetalle")
                    .HasMaxLength(50);

                entity.Property(e => e.ComercialName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Dictamen).HasMaxLength(200);

                entity.Property(e => e.FormaPago).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.RelationType).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ReferenceCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reference_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ReferenceModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reference_ModifiedBy");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.RolId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.RolDescription).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RolCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RolModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_ModifiedBy");
            });

            modelBuilder.Entity<RolPrivilege>(entity =>
            {
                entity.HasKey(e => new { e.RolId, e.PrivilegeId });

                entity.ToTable("Rol_Privilege");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RolPrivilegeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Privilege_Rol_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RolPrivilegeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol_Privilege_Rol_ModifiedBy");
            });

            modelBuilder.Entity<SapCode>(entity =>
            {
                entity.HasKey(e => new { e.SapCodeId, e.ClientId });

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.SapCode1)
                    .HasColumnName("SapCode")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.SapCode)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SapCode_Client");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SapCodeCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SapCode_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SapCodeModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SapCode_ModifiedBy");
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.Property(e => e.SegmentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.SegmentDescription).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SegmentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Segment_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SegmentModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Segment_ModifiedBy");
            });

            modelBuilder.Entity<SolCredit>(entity =>
            {
                entity.HasKey(e => new { e.CreditId, e.ClientId })
                    .HasName("PK_SolCredit_1");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ProyeccionMensual).HasMaxLength(50);

                entity.Property(e => e.ProyeccionVolumenMensualF).HasMaxLength(50);

                entity.Property(e => e.TramitesMensualesEsperados).HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.SolCredit)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolCredit_Client");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SolCreditCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolCredit_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SolCreditModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolCredit_ModifiedBy");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.InverseModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ModifiedBy");
            });

            modelBuilder.Entity<UserRol>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RolId });

                entity.ToTable("User_Rol");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserRolCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserRolModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
