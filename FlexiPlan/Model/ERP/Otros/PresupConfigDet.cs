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
    
    public partial class PresupConfigDet
    {
        public long Id { get; set; }
        public long IdPresupConfigEnc { get; set; }
        public long IdCatalogo { get; set; }
        public short Secuencia { get; set; }
        public long IdEmpresa { get; set; }
    
        public virtual Catalogo Catalogo { get; set; }
        public virtual PresupConfigEnc PresupConfigEnc { get; set; }
    }
}
