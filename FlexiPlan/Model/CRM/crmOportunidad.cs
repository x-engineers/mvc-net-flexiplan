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
    
    public partial class crmOportunidad:Entity<long>
    {
        public static string ESTADO_PENDIENTE = "Pendiente";
        public static string ESTADO_ASIGNADO = "Asignado";
        public static string ESTADO_SIN_ASIGNAR = "SinAsignar";
        public static string ESTADO_PRECALIFICACION = "Precalificacion";
        public static string ESTADO_DENEGADO= "Denegado";
        public static string ESTADO_INACTIVO = "Inactivo";
        public static string ESTADO_CREDITO_SINASIGNAR = "CreditoSinAsignar";
        public static string ESTADO_CREDITO_ASIGNADO = "CreditoAsignado";
        public static string ESTADO_CREDITO_APROBADO = "CreditoAprobado";
        public static string ESTADO_CREDITO_DENEGADO = "CreditoDenegado";
        public static string ESTADO_CREDITO_CONDICIONADO = "CreditoCondicionado";
        public static string ESTADO_CREDITO_INACTIVO = "CreditoInactivo";
        public static string ESTADO_CREDITO_VENTA_FALLIDA = "CreditoVentaFallida";

        public long IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string OrigenConctacto { get; set; }
        public string DescripcionOrigen { get; set; }
        public Nullable<long> IdCampania { get; set; }
        public int IdTipoVenta { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public Nullable<long> IdEmpleado { get; set; }
        public string URLBuro { get; set; }
        public bool URLActiva { get; set; }
        public System.DateTime URLFechaEnvio { get; set; }
        public Nullable<System.DateTime> URLFechaAcepto { get; set; }
        public string BuroNombres { get; set; }
        public string BuroApellidos { get; set; }
        public string BuroGenero { get; set; }
        public string BuroDUI { get; set; }
        public string BuroNIT { get; set; }
        public string BuroCorreo { get; set; }
        public string BuroTelefono { get; set; }
        public string Calificacion { get; set; }
        public string ComentarioCalificacion { get; set; }
        public long IdUsuarioAgrego { get; set; }
        public System.DateTime FechaAgrego { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public Nullable<int> IdTipoMedio { get; set; }
        public Nullable<int> IdMedioContacto { get; set; }
        public Nullable<System.DateTime> FechaComite { get; set; }
        public Nullable<long> IdAnalista { get; set; }
        public Nullable<System.DateTime> FechaAnalisis { get; set; }
        public Nullable<System.DateTime> FechaVenta { get; set; }
        public string ComentarioAnalisis { get; set; }
        public string ComentarioVentaFallida { get; set; }

        public virtual crmTipoVenta crmTipoVenta { get; set; }
    }
}
