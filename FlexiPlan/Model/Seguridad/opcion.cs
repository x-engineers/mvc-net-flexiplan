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
    
    public partial class opcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public opcion()
        {
            this.CatalogoOpcion = new HashSet<CatalogoOpcion>();
        }
    
        public long id { get; set; }
        public long IdAppProject { get; set; }
        public long idpadre { get; set; }
        public string opciontipo { get; set; }
        public string opciondes { get; set; }
        public string programa { get; set; }
        public string vbindex { get; set; }
        public string Posicion { get; set; }
        public string Ico { get; set; }
        public bool activo { get; set; }
        public string filtro { get; set; }
        public string SeleccionSQL { get; set; }
        public short Origen { get; set; }
        public string URL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatalogoOpcion> CatalogoOpcion { get; set; }
    }
}
