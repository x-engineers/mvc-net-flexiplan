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
    
    public partial class DiarioEnc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiarioEnc()
        {
            this.cxpQuedanDet = new HashSet<cxpQuedanDet>();
            this.DiarioDet = new HashSet<DiarioDet>();
        }
    
        public long Id { get; set; }
        public long IdTipoPartida { get; set; }
        public long IdPeriodo { get; set; }
        public long IdUsuario { get; set; }
        public int Numero { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public long IdEmpresa { get; set; }
        public string Origen { get; set; }
        public long IdUsuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public long IdUsuarioModifica { get; set; }
        public System.DateTime fechaModifica { get; set; }
        public long IdConOrigenDiarioDet { get; set; }
        public string NumeroEntrada { get; set; }
        public long IdMonedaFuncional { get; set; }
        public long IdMonedaReporte { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
        public long IdOpcionOrigen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cxpQuedanDet> cxpQuedanDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiarioDet> DiarioDet { get; set; }
        public virtual Periodo Periodo { get; set; }
        public virtual TipoPartida TipoPartida { get; set; }
    }
}