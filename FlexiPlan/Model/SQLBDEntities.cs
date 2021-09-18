namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    /// <summary>
    /// Enlace a EntityFramework para administrar el acceso a datos en todas 
    /// las tablas de los Modulos del ERP.
    /// Para personalizar el manejo de dichas entidades han sida separadas del
    /// autogenerador y se aplican los atributos que sean necesarios a traves
    /// de la aplicacion.
    /// </summary>
    public class SQLBDEntities : DbContext
    {

        /// <summary>
        /// Constructor que permite incluir el nombre de la cadena de conexión.
        /// </summary>
        public SQLBDEntities()
            : base("name=SQLBDEntities")
        {
            Database.CommandTimeout = 3600 * 10; //10 Horas
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<AccesoUsuario> AccesoUsuario { get; set; }
        public virtual DbSet<ActAniosUso> ActAniosUso { get; set; }
        public virtual DbSet<ActivoFijo> ActivoFijo { get; set; }
        public virtual DbSet<AppProject> AppProject { get; set; }
        public virtual DbSet<Asociacion> Asociacion { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<BanConciliacion> BanConciliacion { get; set; }
        public virtual DbSet<BaseDetalleImpuesto> BaseDetalleImpuesto { get; set; }
        public virtual DbSet<Catalogo> Catalogo { get; set; }
        public virtual DbSet<CatalogoCC> CatalogoCC { get; set; }
        public virtual DbSet<CatalogoOpcion> CatalogoOpcion { get; set; }
        public virtual DbSet<CatalogoxCatalogoCC> CatalogoxCatalogoCC { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<ClaseActivo> ClaseActivo { get; set; }
        public virtual DbSet<ClasifEFE> ClasifEFE { get; set; }
        public virtual DbSet<ClasificaCliente> ClasificaCliente { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<ConOrigenDiarioDet> ConOrigenDiarioDet { get; set; }
        public virtual DbSet<ConOrigenDiarioEnc> ConOrigenDiarioEnc { get; set; }
        public virtual DbSet<ConPresupuestoDet> ConPresupuestoDet { get; set; }
        public virtual DbSet<ConPresupuestoEnc> ConPresupuestoEnc { get; set; }
        public virtual DbSet<CorteCaja> CorteCaja { get; set; }
        public virtual DbSet<CortePago> CortePago { get; set; }
        public virtual DbSet<CreditoDet> CreditoDet { get; set; }
        public virtual DbSet<CreditoEnc> CreditoEnc { get; set; }
        public virtual DbSet<CredNoEnc> CredNoEnc { get; set; }
        public virtual DbSet<CriterioCotiza> CriterioCotiza { get; set; }
        public virtual DbSet<crmCampania> crmCampania { get; set; }
        public virtual DbSet<crmCampaniaColorProducto> crmCampaniaColorProducto { get; set; }
        public virtual DbSet<crmCampaniaProdPartes> crmCampaniaProdPartes { get; set; }
        public virtual DbSet<crmCampaniaProdRegalia> crmCampaniaProdRegalia { get; set; }
        public virtual DbSet<crmCampaniaProducto> crmCampaniaProducto { get; set; }
        public virtual DbSet<crmCampaniaSucursal> crmCampaniaSucursal { get; set; }
        public virtual DbSet<crmContacto> crmContacto { get; set; }
        public virtual DbSet<crmContactoArchivos> crmContactoArchivos { get; set; }
        public virtual DbSet<crmContactoDireccion> crmContactoDireccion { get; set; }
        public virtual DbSet<crmContactoInformacionEco> crmContactoInformacionEco { get; set; }
        public virtual DbSet<crmContactoReferencia> crmContactoReferencia { get; set; }
        public virtual DbSet<crmLogAuditoria> crmLogAuditoria { get; set; }
        public virtual DbSet<crmMedioContacto> crmMedioContacto { get; set; }
        public virtual DbSet<crmNivelEducacion> crmNivelEducacion { get; set; }
        public virtual DbSet<crmOportunidad> crmOportunidad { get; set; }
        public virtual DbSet<crmParametro> crmParametro { get; set; }
        public virtual DbSet<crmProfesion> crmProfesion { get; set; }
        public virtual DbSet<crmTasaInteres> crmTasaInteres { get; set; }
        public virtual DbSet<crmTipoCredito> crmTipoCredito { get; set; }
        public virtual DbSet<crmTipoMedio> crmTipoMedio { get; set; }
        public virtual DbSet<crmTipoPropiedad> crmTipoPropiedad { get; set; }
        public virtual DbSet<crmTipoReferencia> crmTipoReferencia { get; set; }
        public virtual DbSet<crmTipoVenta> crmTipoVenta { get; set; }
        public virtual DbSet<crmTipoVivienda> crmTipoVivienda { get; set; }
        public virtual DbSet<crmVentaEnc> crmVentaEnc { get; set; }
        public virtual DbSet<CuentaBanco> CuentaBanco { get; set; }
        public virtual DbSet<cxcTipoTransaccion> cxcTipoTransaccion { get; set; }
        public virtual DbSet<cxcTransacciones> cxcTransacciones { get; set; }
        public virtual DbSet<cxcTransaccionesAplicadas> cxcTransaccionesAplicadas { get; set; }
        public virtual DbSet<CxcTransaccionesCentroCosto> CxcTransaccionesCentroCosto { get; set; }
        public virtual DbSet<CxcTransaccionesContable> CxcTransaccionesContable { get; set; }
        public virtual DbSet<cxpQuedanDet> cxpQuedanDet { get; set; }
        public virtual DbSet<cxpQuedanEnc> cxpQuedanEnc { get; set; }
        public virtual DbSet<cxpTipoTransaccion> cxpTipoTransaccion { get; set; }
        public virtual DbSet<cxpTransacciones> cxpTransacciones { get; set; }
        public virtual DbSet<cxpTransaccionesAplicadas> cxpTransaccionesAplicadas { get; set; }
        public virtual DbSet<CxpTransaccionesCentroCosto> CxpTransaccionesCentroCosto { get; set; }
        public virtual DbSet<CxpTransaccionesContable> CxpTransaccionesContable { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Depreciacion> Depreciacion { get; set; }
        public virtual DbSet<DetalleImpuesto> DetalleImpuesto { get; set; }
        public virtual DbSet<DeudaExterna> DeudaExterna { get; set; }
        public virtual DbSet<Deudor> Deudor { get; set; }
        public virtual DbSet<DiarioDet> DiarioDet { get; set; }
        public virtual DbSet<DiarioEnc> DiarioEnc { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<DocumentoSucursal> DocumentoSucursal { get; set; }
        public virtual DbSet<Ejercicio> Ejercicio { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstResConfig> EstResConfig { get; set; }
        public virtual DbSet<EstResultado> EstResultado { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<FormaPagoTarjeta> FormaPagoTarjeta { get; set; }
        public virtual DbSet<FTLog> FTLog { get; set; }
        public virtual DbSet<General> General { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Inactivos> Inactivos { get; set; }
        public virtual DbSet<invactivodet> invactivodet { get; set; }
        public virtual DbSet<invactivoenc> invactivoenc { get; set; }
        public virtual DbSet<InvClase> InvClase { get; set; }
        public virtual DbSet<InvClasif> InvClasif { get; set; }
        public virtual DbSet<InvColor> InvColor { get; set; }
        public virtual DbSet<InvCombo> InvCombo { get; set; }
        public virtual DbSet<InvCondicionPago> InvCondicionPago { get; set; }
        public virtual DbSet<InvCostoDescarga> InvCostoDescarga { get; set; }
        public virtual DbSet<InvDescDet> InvDescDet { get; set; }
        public virtual DbSet<InvDescEnc> InvDescEnc { get; set; }
        public virtual DbSet<InvDivision> InvDivision { get; set; }
        public virtual DbSet<InvEstadoParte> InvEstadoParte { get; set; }
        public virtual DbSet<InvEstadoProducto> InvEstadoProducto { get; set; }
        public virtual DbSet<InvExistencia> InvExistencia { get; set; }
        public virtual DbSet<InvFisDet> InvFisDet { get; set; }
        public virtual DbSet<InvFisEnc> InvFisEnc { get; set; }
        public virtual DbSet<InvGrupo> InvGrupo { get; set; }
        public virtual DbSet<InvListaPrecioDet> InvListaPrecioDet { get; set; }
        public virtual DbSet<InvListaPrecioEnc> InvListaPrecioEnc { get; set; }
        public virtual DbSet<InvLote> InvLote { get; set; }
        public virtual DbSet<InvLoteDet> InvLoteDet { get; set; }
        public virtual DbSet<InvMarca> InvMarca { get; set; }
        public virtual DbSet<InvMedida> InvMedida { get; set; }
        public virtual DbSet<InvMetodoCalculo> InvMetodoCalculo { get; set; }
        public virtual DbSet<InvMetodoPrecio> InvMetodoPrecio { get; set; }
        public virtual DbSet<InvModelo> InvModelo { get; set; }
        public virtual DbSet<InvMovDet> InvMovDet { get; set; }
        public virtual DbSet<InvMovDetTalla> InvMovDetTalla { get; set; }
        public virtual DbSet<InvMovEnc> InvMovEnc { get; set; }
        public virtual DbSet<InvMovEncCentroCosto> InvMovEncCentroCosto { get; set; }
        public virtual DbSet<InvMovEncContable> InvMovEncContable { get; set; }
        public virtual DbSet<InvMovEncCostosDescarga> InvMovEncCostosDescarga { get; set; }
        public virtual DbSet<InvMovEncImpuesto> InvMovEncImpuesto { get; set; }
        public virtual DbSet<InvMovEncPago> InvMovEncPago { get; set; }
        public virtual DbSet<InvNivelPrecio> InvNivelPrecio { get; set; }
        public virtual DbSet<InvPago> InvPago { get; set; }
        public virtual DbSet<InvPlanUMDet> InvPlanUMDet { get; set; }
        public virtual DbSet<InvPlanUMEnc> InvPlanUMEnc { get; set; }
        public virtual DbSet<InvProducto> InvProducto { get; set; }
        public virtual DbSet<InvProductoPartes> InvProductoPartes { get; set; }
        public virtual DbSet<InvRubro> InvRubro { get; set; }
        public virtual DbSet<InvTalla> InvTalla { get; set; }
        public virtual DbSet<InvTipoDocumento> InvTipoDocumento { get; set; }
        public virtual DbSet<InvTipoMov> InvTipoMov { get; set; }
        public virtual DbSet<InvTipoProrrateo> InvTipoProrrateo { get; set; }
        public virtual DbSet<InvValoracion> InvValoracion { get; set; }
        public virtual DbSet<LugarTrabajo> LugarTrabajo { get; set; }
        public virtual DbSet<Meses> Meses { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<MonedaDenominacion> MonedaDenominacion { get; set; }
        public virtual DbSet<MovCaja> MovCaja { get; set; }
        public virtual DbSet<MovimientoBanco> MovimientoBanco { get; set; }
        public virtual DbSet<Multimoneda> Multimoneda { get; set; }
        public virtual DbSet<opcion> opcion { get; set; }
        public virtual DbSet<OrdenarCompra> OrdenarCompra { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Parentezco> Parentezco { get; set; }
        public virtual DbSet<Parientes> Parientes { get; set; }
        public virtual DbSet<PerfilDet> PerfilDet { get; set; }
        public virtual DbSet<PerfilEnc> PerfilEnc { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<PlanImpuesto> PlanImpuesto { get; set; }
        public virtual DbSet<PlanXDetalleImpuesto> PlanXDetalleImpuesto { get; set; }
        public virtual DbSet<POSTarjeta> POSTarjeta { get; set; }
        public virtual DbSet<PresupConfigDet> PresupConfigDet { get; set; }
        public virtual DbSet<PresupConfigEnc> PresupConfigEnc { get; set; }
        public virtual DbSet<Presupuesto> Presupuesto { get; set; }
        public virtual DbSet<Prioridad> Prioridad { get; set; }
        public virtual DbSet<ProgramaCxP> ProgramaCxP { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<PuntoVenta> PuntoVenta { get; set; }
        public virtual DbSet<Ratio> Ratio { get; set; }
        public virtual DbSet<RetiroEmpleado> RetiroEmpleado { get; set; }
        public virtual DbSet<rptFiltros> rptFiltros { get; set; }
        public virtual DbSet<rrhCargo> rrhCargo { get; set; }
        public virtual DbSet<rrhClaseEmpleado> rrhClaseEmpleado { get; set; }
        public virtual DbSet<rrhEmpleado> rrhEmpleado { get; set; }
        public virtual DbSet<SaldoBanco> SaldoBanco { get; set; }
        public virtual DbSet<SaldoCC> SaldoCC { get; set; }
        public virtual DbSet<SaldoConta> SaldoConta { get; set; }
        public virtual DbSet<SolicitudDet> SolicitudDet { get; set; }
        public virtual DbSet<SolicitudEnc> SolicitudEnc { get; set; }
        public virtual DbSet<SolicitudExt> SolicitudExt { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<TipoAbono> TipoAbono { get; set; }
        public virtual DbSet<TipoActividad> TipoActividad { get; set; }
        public virtual DbSet<TipoActivo> TipoActivo { get; set; }
        public virtual DbSet<TipoAhorro> TipoAhorro { get; set; }
        public virtual DbSet<TipoCredito> TipoCredito { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
        public virtual DbSet<TipoExterno> TipoExterno { get; set; }
        public virtual DbSet<TipoMovBanco> TipoMovBanco { get; set; }
        public virtual DbSet<TipoMovCaja> TipoMovCaja { get; set; }
        public virtual DbSet<TipoOrden> TipoOrden { get; set; }
        public virtual DbSet<TipoPartida> TipoPartida { get; set; }
        public virtual DbSet<TipoSucursal> TipoSucursal { get; set; }
        public virtual DbSet<TipoUsoOrden> TipoUsoOrden { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Filtro> Filtro { get; set; }
        public virtual DbSet<FTLocks> FTLocks { get; set; }
        public virtual DbSet<IvarptBase> IvarptBase { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<TipoMovIVA> TipoMovIVA { get; set; }
        public virtual DbSet<vwInvListaProductoPartes> vwInvListaProductoPartes { get; set; }
        public virtual DbSet<vwListaProductos> vwListaProductos { get; set; }
        public virtual DbSet<vwrptCrmContacto> vwrptCrmContacto { get; set; }
        public virtual DbSet<vwrptCrmContactoDirecciones> vwrptCrmContactoDirecciones { get; set; }
        public virtual DbSet<vwrptCrmContactoInformacionEco> vwrptCrmContactoInformacionEco { get; set; }
        public virtual DbSet<vwrptCrmContactoReferencias> vwrptCrmContactoReferencias { get; set; }

        public virtual int sp_CrearActualizarCliente(Nullable<long> idEmpresa, Nullable<long> idSucursal, Nullable<long> idContacto, string nombre, Nullable<long> idPlanImpuesto, Nullable<byte> idInvCondicionPago, Nullable<long> idDocumento, Nullable<long> idUsuario, Nullable<long> idCliente, string codigo, Nullable<long> idLugarTrabajo, string direccion, Nullable<long> idCiudad, Nullable<long> idEstado, Nullable<long> idPais, string dUI, string nIT, string nRC, string giro, string telefono1, string telefono2, string eMail, string sexo, string webSite, Nullable<decimal> montoCredito, Nullable<long> idrrhEmpleado, Nullable<long> idInvNivelPrecio, Nullable<short> accion)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(long));

            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(long));

            var idContactoParameter = idContacto.HasValue ?
                new ObjectParameter("IdContacto", idContacto) :
                new ObjectParameter("IdContacto", typeof(long));

            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));

            var idPlanImpuestoParameter = idPlanImpuesto.HasValue ?
                new ObjectParameter("IdPlanImpuesto", idPlanImpuesto) :
                new ObjectParameter("IdPlanImpuesto", typeof(long));

            var idInvCondicionPagoParameter = idInvCondicionPago.HasValue ?
                new ObjectParameter("IdInvCondicionPago", idInvCondicionPago) :
                new ObjectParameter("IdInvCondicionPago", typeof(byte));

            var idDocumentoParameter = idDocumento.HasValue ?
                new ObjectParameter("IdDocumento", idDocumento) :
                new ObjectParameter("IdDocumento", typeof(long));

            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(long));

            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(long));

            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));

            var idLugarTrabajoParameter = idLugarTrabajo.HasValue ?
                new ObjectParameter("IdLugarTrabajo", idLugarTrabajo) :
                new ObjectParameter("IdLugarTrabajo", typeof(long));

            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));

            var idCiudadParameter = idCiudad.HasValue ?
                new ObjectParameter("IdCiudad", idCiudad) :
                new ObjectParameter("IdCiudad", typeof(long));

            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(long));

            var idPaisParameter = idPais.HasValue ?
                new ObjectParameter("IdPais", idPais) :
                new ObjectParameter("IdPais", typeof(long));

            var dUIParameter = dUI != null ?
                new ObjectParameter("DUI", dUI) :
                new ObjectParameter("DUI", typeof(string));

            var nITParameter = nIT != null ?
                new ObjectParameter("NIT", nIT) :
                new ObjectParameter("NIT", typeof(string));

            var nRCParameter = nRC != null ?
                new ObjectParameter("NRC", nRC) :
                new ObjectParameter("NRC", typeof(string));

            var giroParameter = giro != null ?
                new ObjectParameter("Giro", giro) :
                new ObjectParameter("Giro", typeof(string));

            var telefono1Parameter = telefono1 != null ?
                new ObjectParameter("Telefono1", telefono1) :
                new ObjectParameter("Telefono1", typeof(string));

            var telefono2Parameter = telefono2 != null ?
                new ObjectParameter("Telefono2", telefono2) :
                new ObjectParameter("Telefono2", typeof(string));

            var eMailParameter = eMail != null ?
                new ObjectParameter("eMail", eMail) :
                new ObjectParameter("eMail", typeof(string));

            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));

            var webSiteParameter = webSite != null ?
                new ObjectParameter("WebSite", webSite) :
                new ObjectParameter("WebSite", typeof(string));

            var montoCreditoParameter = montoCredito.HasValue ?
                new ObjectParameter("MontoCredito", montoCredito) :
                new ObjectParameter("MontoCredito", typeof(decimal));

            var idrrhEmpleadoParameter = idrrhEmpleado.HasValue ?
                new ObjectParameter("IdrrhEmpleado", idrrhEmpleado) :
                new ObjectParameter("IdrrhEmpleado", typeof(long));

            var idInvNivelPrecioParameter = idInvNivelPrecio.HasValue ?
                new ObjectParameter("IdInvNivelPrecio", idInvNivelPrecio) :
                new ObjectParameter("IdInvNivelPrecio", typeof(long));

            var accionParameter = accion.HasValue ?
                new ObjectParameter("Accion", accion) :
                new ObjectParameter("Accion", typeof(short));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CrearActualizarCliente", idEmpresaParameter, idSucursalParameter, idContactoParameter, nombreParameter, idPlanImpuestoParameter, idInvCondicionPagoParameter, idDocumentoParameter, idUsuarioParameter, idClienteParameter, codigoParameter, idLugarTrabajoParameter, direccionParameter, idCiudadParameter, idEstadoParameter, idPaisParameter, dUIParameter, nITParameter, nRCParameter, giroParameter, telefono1Parameter, telefono2Parameter, eMailParameter, sexoParameter, webSiteParameter, montoCreditoParameter, idrrhEmpleadoParameter, idInvNivelPrecioParameter, accionParameter);
        }
    }
}
