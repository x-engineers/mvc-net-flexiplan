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
    
    public partial class Parientes
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public long IdParentezco { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaNac { get; set; }
        public bool Beneficiario { get; set; }
        public decimal Porcentaje { get; set; }
        public string Sexo { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Parentezco Parentezco { get; set; }
    }
}
