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
    
    public partial class InvDescEnc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvDescEnc()
        {
            this.InvDescDet = new HashSet<InvDescDet>();
        }
    
        public long Id { get; set; }
        public long IdPuntoVenta { get; set; }
        public Nullable<decimal> Numero { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public long IdEmpresa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDescDet> InvDescDet { get; set; }
        public virtual PuntoVenta PuntoVenta { get; set; }
    }
}
