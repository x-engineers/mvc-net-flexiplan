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
    
    public partial class InvListaPrecioEnc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvListaPrecioEnc()
        {
            this.InvListaPrecioDet = new HashSet<InvListaPrecioDet>();
        }
    
        public long Id { get; set; }
        public long IdInvProducto { get; set; }
        public long IdInvMetodoPrecio { get; set; }
        public long IdInvNivelPrecio { get; set; }
        public long IdEmpresa { get; set; }
        public long IdInvMedida { get; set; }
        public bool IncluyeImpuesto { get; set; }
        public long IdDetalleImpuesto { get; set; }
        public long IdInvPlanUMEnc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvListaPrecioDet> InvListaPrecioDet { get; set; }
        public virtual InvProducto InvProducto { get; set; }
    }
}
