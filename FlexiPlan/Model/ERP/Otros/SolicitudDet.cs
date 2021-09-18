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
    
    public partial class SolicitudDet
    {
        public long Id { get; set; }
        public long IdDeudor { get; set; }
        public long IdCreditoEnc { get; set; }
        public decimal CuotaCredito { get; set; }
        public string Frecuencia { get; set; }
        public System.DateTime FechaSaldo { get; set; }
        public decimal Saldo { get; set; }
        public decimal MontoDescontar { get; set; }
        public decimal Interes { get; set; }
        public decimal Seguro { get; set; }
        public decimal Mora { get; set; }
        public bool Descontar { get; set; }
    
        public virtual CreditoEnc CreditoEnc { get; set; }
        public virtual Deudor Deudor { get; set; }
    }
}
