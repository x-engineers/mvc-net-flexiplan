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
    
    public partial class SolicitudExt
    {
        public long Id { get; set; }
        public long IdDeudor { get; set; }
        public long IdDeudaExterna { get; set; }
        public string Frecuencia { get; set; }
        public long Monto { get; set; }
        public long CuotaCredito { get; set; }
        public System.DateTime FechaCredito { get; set; }
    
        public virtual DeudaExterna DeudaExterna { get; set; }
        public virtual Deudor Deudor { get; set; }
    }
}
