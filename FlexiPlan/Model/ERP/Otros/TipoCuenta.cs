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
    
    public partial class TipoCuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoCuenta()
        {
            this.Catalogo = new HashSet<Catalogo>();
        }
    
        public long ID { get; set; }
        public string TipoCuentaDes { get; set; }
        public Nullable<bool> Balance { get; set; }
        public Nullable<bool> Resultado { get; set; }
        public string NomCorto { get; set; }
        public long IdEmpresa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalogo> Catalogo { get; set; }
    }
}