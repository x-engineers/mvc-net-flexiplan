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
    
    public partial class InvMovDet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvMovDet()
        {
            this.InvMovDetTalla = new HashSet<InvMovDetTalla>();
        }
    
        public long Id { get; set; }
        public long IdInvMovEnc { get; set; }
        public long IdInvProducto { get; set; }
        public long IdInvExistencia { get; set; }
        public long IdPadre { get; set; }
        public short Secuencia { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal TasaDescuento { get; set; }
        public decimal TasaIva { get; set; }
        public decimal TasaCosto { get; set; }
        public decimal TasaPrecio { get; set; }
        public decimal ExistAnt { get; set; }
        public decimal CostoAnt { get; set; }
        public decimal PrecioAnt { get; set; }
        public bool CambiaPrecio { get; set; }
        public bool Consignacion { get; set; }
        public bool Exento { get; set; }
        public bool NoSujeta { get; set; }
        public bool Autorizar { get; set; }
        public Nullable<byte> Autorizado { get; set; }
        public decimal CantBodega { get; set; }
        public string Concepto { get; set; }
        public long IdCatalogo { get; set; }
        public long IdEmpresa { get; set; }
        public bool Averia { get; set; }
        public long IdCatalogo1 { get; set; }
        public long IdCatalogo2 { get; set; }
        public long IdCatalogo3 { get; set; }
        public long IdCatalogo4 { get; set; }
        public long IdCatalogo5 { get; set; }
        public long IdCatalogo6 { get; set; }
        public long IdCatalogo7 { get; set; }
        public long IdCatalogo8 { get; set; }
        public long IdInvListaPrecioDet { get; set; }
        public long IdInvNivelPrecio { get; set; }
        public long IdInvMedida { get; set; }
        public bool Servicio { get; set; }
        public bool IncluyeImpuesto { get; set; }
        public long IdDetalleImpuesto { get; set; }
        public long IdPlanImpuesto { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public long IdInvProductoPartes { get; set; }
        public string NumeroParte { get; set; }
        public string NumeroSerie { get; set; }
        public decimal ExistAntParte { get; set; }
        public long IdInvOrdenCompraDet { get; set; }
        public long IdSucursal { get; set; }
        public long IdSucursalDestino { get; set; }
        public decimal FactorBaseUM { get; set; }
        public long IdInvPlanUMEnc { get; set; }
        public byte Decimales { get; set; }
        public long IdInvRubro { get; set; }
        public long IdInvTalla { get; set; }
        public short IdInvColor { get; set; }
        public string Placa { get; set; }
        public short Anio { get; set; }
        public int Kilometraje { get; set; }
        public decimal PrecioOriginal { get; set; }
        public decimal CantidadOriginal { get; set; }
        public decimal CostoOriginal { get; set; }
        public decimal TotalCosto { get; set; }
        public decimal CantidadDespacho { get; set; }
    
        public virtual InvMovEnc InvMovEnc { get; set; }
        public virtual InvProducto InvProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvMovDetTalla> InvMovDetTalla { get; set; }
    }
}
