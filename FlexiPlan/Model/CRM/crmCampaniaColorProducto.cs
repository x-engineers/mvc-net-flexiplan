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
    
    public partial class crmCampaniaColorProducto:Entity<long>
    {
        public long IdEmpresa { get; set; }
        public long IdCampania { get; set; }
        public long IdInvColor { get; set; }
    
        public virtual crmCampania crmCampania { get; set; }
        public virtual InvColor InvColor { get; set; }
    }
}