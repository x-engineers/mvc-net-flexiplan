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

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Asociacion = new HashSet<Asociacion>();
            this.CreditoEnc = new HashSet<CreditoEnc>();
            this.cxpQuedanEnc = new HashSet<cxpQuedanEnc>();
            this.DeudaExterna = new HashSet<DeudaExterna>();
            this.Deudor = new HashSet<Deudor>();
            this.Inactivos = new HashSet<Inactivos>();
            this.InvMovEnc = new HashSet<InvMovEnc>();
            this.OrdenarCompra = new HashSet<OrdenarCompra>();
            this.Parientes = new HashSet<Parientes>();
            this.Proyecto = new HashSet<Proyecto>();
            this.RetiroEmpleado = new HashSet<RetiroEmpleado>();
        }

        public long Id { get; set; }
        public long IdLugarTrabajo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Bloqueado { get; set; }
        public string Direccion { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string NRC { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string eMail { get; set; }
        public string Sexo { get; set; }
        public Nullable<long> IdBanco { get; set; }
        public string NumCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string WebSite { get; set; }
        public string Giro { get; set; }
        public string ArchivoFoto { get; set; }
        public short Plazo { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal SobreGiro { get; set; }
        public string Contacto { get; set; }
        public long IdPlanImpuesto { get; set; }
        public long IdEmpresa { get; set; }
        public long IdCatalogo1 { get; set; }
        public long IdCatalogo2 { get; set; }
        public long IdCatalogo3 { get; set; }
        public long IdCatalogo4 { get; set; }
        public long IdCatalogoCC { get; set; }
        public long IdDocumento { get; set; }
        public long IdrrhEmpleado { get; set; }
        public long IdCiudad { get; set; }
        public long IdEstado { get; set; }
        public long IdPais { get; set; }
        public byte IdInvCondicionPago { get; set; }
        public long IdUsuario { get; set; }
        public long IdCatalogo5 { get; set; }
        public long IdInvNivelPrecio { get; set; }
        public long IdSucursal { get; set; }
        public string CalleAvenidaPasajePoligonoBlock { get; set; }
        public string NumeroCasa { get; set; }
        public string AparatamentoLocal { get; set; }
        public string DatosComplementarios { get; set; }
        public string ColoniaBarrioResidenciaReparto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asociacion> Asociacion { get; set; }
        public virtual PlanImpuesto PlanImpuesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditoEnc> CreditoEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cxpQuedanEnc> cxpQuedanEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeudaExterna> DeudaExterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deudor> Deudor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inactivos> Inactivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvMovEnc> InvMovEnc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenarCompra> OrdenarCompra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parientes> Parientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetiroEmpleado> RetiroEmpleado { get; set; }
    }
}
