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
    
    public partial class AsignacionSolicitud
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdContacto { get; set; }
        public bool Estado { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public byte EstadoAsignacion { get; set; }
        public Nullable<int> IdEstadoAsignacion { get; set; }
    
        public virtual EstadoAsignacion EstadoAsignacion1 { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
