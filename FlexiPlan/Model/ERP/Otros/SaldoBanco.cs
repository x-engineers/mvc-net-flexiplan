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
    
    public partial class SaldoBanco
    {
        public long Id { get; set; }
        public long IdPeriodo { get; set; }
        public long IdCuentaBanco { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoIngreso { get; set; }
        public decimal SaldoEgreso { get; set; }
        public long IdEmpresa { get; set; }
        public long IdMonedaFuncional { get; set; }
        public long IdMonedaReporte { get; set; }
    
        public virtual CuentaBanco CuentaBanco { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
