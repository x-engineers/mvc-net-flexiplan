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
    
    public partial class EstResultado
    {
        public long Id { get; set; }
        public long IdPadre { get; set; }
        public long IdCatalogo { get; set; }
        public string EstResultadoDes { get; set; }
        public short Orden { get; set; }
        public bool Incluir { get; set; }
        public short Signo { get; set; }
        public long IdEmpresa { get; set; }
    }
}
