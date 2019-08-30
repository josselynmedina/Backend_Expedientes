//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiExpedientes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Contactoes = new HashSet<Contacto>();
            this.Inconsistencias = new HashSet<Inconsistencia>();
            this.Proveedors = new HashSet<Proveedor>();
            this.SolicitudCreditoes = new HashSet<SolicitudCredito>();
        }
    
        public int ClienteId { get; set; }
        public string GrupoEmpresarial { get; set; }
        public string RegistroTributario { get; set; }
        public int TipoRegistro { get; set; }
        public string Direccion { get; set; }
        public string WebPage { get; set; }
        public string Actividad { get; set; }
        public int LineaProducto { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
        public string Valores { get; set; }
        public int Pais { get; set; }
        public string Telefono { get; set; }
        public string Industria { get; set; }
        public int TipoIndustria { get; set; }
        public int Segmento { get; set; }
        public string RSE { get; set; }
        public string Marcas { get; set; }
        public int Mercado { get; set; }
        public int PaisFacturacion { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual Pai Pai { get; set; }
        public virtual Pai Pai1 { get; set; }
        public virtual Pai Pai2 { get; set; }
        public virtual TipoIndustria TipoIndustria1 { get; set; }
        public virtual TipoFiscal TipoFiscal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contacto> Contactoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inconsistencia> Inconsistencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudCredito> SolicitudCreditoes { get; set; }
        public virtual LineaProducto LineaProducto1 { get; set; }
        public virtual Segmento Segmento1 { get; set; }
    }
}