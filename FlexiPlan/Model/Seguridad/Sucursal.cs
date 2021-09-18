//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sucursal:Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sucursal()
        {
            this.CreditoEnc = new HashSet<CreditoEnc>();
            this.crmCampaniaSucursal = new HashSet<crmCampaniaSucursal>();
            this.cxpQuedanEnc = new HashSet<cxpQuedanEnc>();
            this.InvExistencia = new HashSet<InvExistencia>();
            this.InvFisEnc = new HashSet<InvFisEnc>();
            this.InvMovEnc = new HashSet<InvMovEnc>();
            this.PuntoVenta = new HashSet<PuntoVenta>();
            this.SolicitudEnc = new HashSet<SolicitudEnc>();
        }
    
        public string SucursalDes { get; set; }
        public bool Primaria { get; set; }
        public long IdEmpresa { get; set; }
        public string Direccion { get; set; }
        public long IdCiudad { get; set; }
        public long IdEstado { get; set; }
        public long IdPais { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public long IdPlanImpuestoCompra { get; set; }
        public long IdPlanImpuestoVenta { get; set; }
        public long IdCatalogo1 { get; set; }
        public long IdCatalogo2 { get; set; }
        public long IdCatalogo3 { get; set; }
        public long IdCatalogo4 { get; set; }
        public long IdCatalogo5 { get; set; }
        public long IdCatalogo6 { get; set; }
        public long IdCatalogo7 { get; set; }
        public long IdCatalogo8 { get; set; }
        public long IdInvClasif { get; set; }
        public short IdTipoSucursal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditoEnc> CreditoEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crmCampaniaSucursal> crmCampaniaSucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cxpQuedanEnc> cxpQuedanEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvExistencia> InvExistencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvFisEnc> InvFisEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvMovEnc> InvMovEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PuntoVenta> PuntoVenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudEnc> SolicitudEnc { get; set; }
    }
}
