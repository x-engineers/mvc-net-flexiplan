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

    public partial class crmContacto : Entity<long>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crmContacto()
        {
            this.crmContactoArchivos = new HashSet<crmContactoArchivos>();
            this.crmContactoDireccion = new HashSet<crmContactoDireccion>();
            this.crmContactoInformacionEco = new HashSet<crmContactoInformacionEco>();
            this.crmContactoReferencia = new HashSet<crmContactoReferencia>();
        }

        //--ESTADO DEL CONTACTO----------------------------------------------
        //--Pendiente -- solo cuando se aya creado la ficha del cliente
        //--Resolución -- solo las puede ver en comite de credito despues de crearlo
        //--Aprobado --  Calificacion de comite de credito lito para crear venta
        //--Condicionado--  Calificacion de comite de credito lito para crear venta
        //--Denegado--  Calificacion de comite de credito solo podra inactivar el contacto
        //--Cliente -- solo cuando se cree la venta credito o al contado
        //--Inactivo -- desaparecera de todo el sistema pero quedara en la BD cuando sea Denegado

        public static string ESTADO_PENDIENTE = "Pendiente";
        public static string ESTADO_CLIENTE = "Cliente";
        public static string ESTADO_INACTIVO = "Inactivo";

        public long IdEmpresa { get; set; }
        public long IdSucursal { get; set; }
        public long IdOportunidad { get; set; }
        public long IdCliente { get; set; }
        public int IdTipoVenta { get; set; }
        public Nullable<long> CondIdMarca { get; set; }
        public Nullable<long> CondIdNivelPrecio { get; set; }
        public Nullable<long> CondIdProducto { get; set; }
        public Nullable<long> CondIdInvProductoPartes { get; set; }
        public Nullable<long> CondIdProductoAccesorio { get; set; }
        public Nullable<long> CondIdProductoParteServio { get; set; }
        public Nullable<short> CondIdTasaInteres { get; set; }
        public Nullable<long> CondIdInvCondicionPago { get; set; }
        public string CondTipoDescuento { get; set; }
        public Nullable<decimal> CondValorDescuento { get; set; }
        public Nullable<decimal> CondPrecioActual { get; set; }
        public Nullable<decimal> CondPrecioNuevo { get; set; }
        public string CondTipoPrima { get; set; }
        public Nullable<decimal> CondvalorPrima { get; set; }
        public Nullable<long> CondGarantia { get; set; }
        public Nullable<short> CondPrimerCuota { get; set; }
        public Nullable<decimal> CondMontoCuotas { get; set; }
        public Nullable<decimal> CondMontoFinciado { get; set; }
        public Nullable<System.DateTime> CondFechaPrimerPago { get; set; }
        public bool EsIndependiente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string ConocidoPor { get; set; }
        public string Genero { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public long IdCiudad { get; set; }
        public string Nacionalidad { get; set; }
        public int IdNivelEducacion { get; set; }
        public int IdProfesion { get; set; }
        public long IdEstadoCivil { get; set; }
        public string Estado { get; set; }
        public string ActNombreEmpresa { get; set; }
        public string ActActividad { get; set; }
        public string ActIdDepartamento { get; set; }
        public string ActIdMunicipio { get; set; }
        public string ActCalle { get; set; }
        public string ActPasaje { get; set; }
        public string ActColonia { get; set; }
        public int ActNumeroCasa { get; set; }
        public string ActReferenciaUbicacion { get; set; }
        public Nullable<bool> ActIndDeclaraImpuesto { get; set; }
        public Nullable<int> ActIndAntiguedad { get; set; }
        public string ActIndTipoLocal { get; set; }
        public Nullable<int> ActIndNumeroEmpleados { get; set; }
        public string ActIndTipoSector { get; set; }
        public Nullable<int> ActIndCantidadLocales { get; set; }
        public string ActIndDireccion2 { get; set; }
        public string ActIndDireccion3 { get; set; }
        public string ActIndDireccion4 { get; set; }
        public string ActDepJefe { get; set; }
        public Nullable<System.DateTime> ActDepFechaIngreso { get; set; }
        public string ActDepTipoContrato { get; set; }
        public string ActDepTipoSueldo { get; set; }
        public Nullable<decimal> ActDepIngresoFijo { get; set; }
        public Nullable<decimal> ActDepIngresoVariable { get; set; }
        public Nullable<int> ActDepDiaPago { get; set; }
        public string ActDepFormaPago { get; set; }
        public string ActDepCargo { get; set; }
        public string ActDepTelefono { get; set; }
        public string ActDepCelular { get; set; }
        public string ConyugeNombres { get; set; }
        public string ConyugeApellidos { get; set; }
        public string ConyugeConocidoPor { get; set; }
        public string ConyugeGenero { get; set; }
        public string ConyugeEmpresa { get; set; }
        public string ConyugeActividadEmpresa { get; set; }
        public string ConyugeCargoEmpresa { get; set; }
        public string ConyugeTelefonoEmpresa { get; set; }
        public Nullable<decimal> ConyugeIngresoMensual { get; set; }
        public Nullable<System.DateTime> ConyugeFechaIngreso { get; set; }
        public Nullable<bool> ValidaCondicionesCred { get; set; }
        public Nullable<System.DateTime> FechaValidaCondicionesCred { get; set; }
        public Nullable<bool> ValidaDatosCliente { get; set; }
        public Nullable<System.DateTime> FechaValidaDatosCliente { get; set; }
        public Nullable<bool> ValidaDatosConyuge { get; set; }
        public Nullable<System.DateTime> FechaValidaDatosConyuge { get; set; }
        public Nullable<bool> ValidaActividadEco { get; set; }
        public Nullable<System.DateTime> FechaValidaActividadEco { get; set; }
        public long IdUsuarioAgrego { get; set; }
        public System.DateTime FechaAgrego { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public int NumeroDependientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crmContactoArchivos> crmContactoArchivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crmContactoDireccion> crmContactoDireccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crmContactoInformacionEco> crmContactoInformacionEco { get; set; }
        public virtual crmNivelEducacion crmNivelEducacion { get; set; }
        public virtual crmProfesion crmProfesion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crmContactoReferencia> crmContactoReferencia { get; set; }
    }
}