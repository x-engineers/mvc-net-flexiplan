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
    
    public partial class rptMayAux
    {
        public long idperiodo { get; set; }
        public string periododes { get; set; }
        public Nullable<long> Idcatalogo { get; set; }
        public string Codigo { get; set; }
        public string CatalogoDes { get; set; }
        public decimal saldoinicial { get; set; }
        public decimal saldocargo { get; set; }
        public decimal saldoabono { get; set; }
        public Nullable<decimal> SaldoPeriodo { get; set; }
        public Nullable<decimal> SaldoFinal { get; set; }
        public Nullable<int> numero { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string concepto { get; set; }
        public Nullable<decimal> Cargos { get; set; }
        public Nullable<decimal> Abonos { get; set; }
        public string Tipo { get; set; }
        public long idempresa { get; set; }
    }
}