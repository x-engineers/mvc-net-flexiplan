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
    
    public partial class InvTipoDocumento
    {
        public long Id { get; set; }
        public string InvTipoDocumentoDes { get; set; }
        public short Signo { get; set; }
        public bool Postear { get; set; }
        public long IdInvTipoMov { get; set; }
    }
}