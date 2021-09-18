using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blo.Mercadeo;
using Blo.Solicitud;
using Blo.Properties;
using Model;
using Ninject;
using Blo;
using System.Reflection;
using Blo.Seguridad;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System.IO;

namespace View.Controllers.Solicitud
{

    [NoCache]
    [Autorizacion]
    public class ResolucionController : BaseController
    {
        /// <summary>
        /// instancia de la interfas para poder hacer el CRUD
        /// </summary>

        //condiciones de crédito
        [Inject]
        public ICampaniaBlo _campaniaBlo { get; set; }
        [Inject]
        public ISucursalBlo _sucursalesBlo { get; set; }
        [Inject]
        public IProductosBlo _productosBlo { get; set; }
        [Inject]
        public IClaseBlo _claseBlo { get; set; }
        [Inject]
        public ITipoVentaBlo _tipoVentaBlo { get; set; }
        [Inject]
        public INivelPrecioBlo _nivelPrecioBlo { get; set; }
        [Inject]
        public IEstadoProductoBlo _estadoProductoBlo { get; set; }
        [Inject]
        public IColorBlo _colorBlo { get; set; }
        [Inject]
        public IMarcaBlo _marcaBlo { get; set; }
        [Inject]
        public ICampaniaProductoBlo _campaniaProductoBlo { get; set; }
        [Inject]
        public ICampaniaProdPartesBlo _campaniaProdPartesBlo { get; set; }
        [Inject]
        public ICampaniaColorProductoBlo _campaniaColorProductoBlo { get; set; }
        [Inject]
        public ICampaniaSucursalBlo _campaniaSucursalBlo { get; set; }
        [Inject]
        public ICampaniaProdRegaliaBlo _campaniaProdRegaliaBlo { get; set; }
        [Inject]
        public ICondicionPagoBlo _condicionPagoBlo { get; set; }
        [Inject]
        public ITasaInteresBlo _tasaInteresBlo { get; set; }

        //contacto
        [Inject]
        public IOportunidadBlo _oportunidadBlo { get; set; }
        [Inject]
        public IContactoBlo _contactoBlo { get; set; }
        [Inject]
        public INivelEducacionBlo _nivelEducacionBlo { get; set; }
        [Inject]
        public IProfesionBlo _profesionBlo { get; set; }
        [Inject]
        public IEstadoCivilBlo _estadoCivilBlo { get; set; }
        [Inject]
        public ICiudadBlo _ciudadBlo { get; set; }
        [Inject]
        public IContactoArchivosBlo _contactoArchivosBlo { get; set; }

        //direcciones
        [Inject]
        public IContactoDireccionBlo _contactoDireccionBlo { get; set; }
        [Inject]
        public ITipoViviendaBlo _tipoViviendaBlo { get; set; }
        [Inject]
        public ITipoDireccionBlo _tipoDireccionBlo { get; set; }
        [Inject]
        public IDepartamentoBlo _departamentoBlo { get; set; }

        //información económica
        [Inject]
        public IContactoInformacionEcoBlo _contactoInformacionEcoBlo { get; set; }
        [Inject]
        public ITipoPropiedadBlo _tipoPropiedadBlo { get; set; }

        //referencias
        [Inject]
        public IContactoReferenciaBlo _contactoReferenciaBlo { get; set; }
        [Inject]
        public ITipoReferenciaBlo _tipoReferenciaBlo { get; set; }


        public ActionResult Index()
        {
            //condiciones del credito
            ViewBag.marca = _marcaBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.nivelPrecio = _nivelPrecioBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.servicios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_SERVICIO);
            ViewBag.accesorios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_ACCESORIO);
            ViewBag.condicionPago = _condicionPagoBlo.GetCondicionesPago(GetEmpresa());
            ViewBag.tasaInteres = _tasaInteresBlo.GetTasaInteres();
            //para contacto
            ViewBag.nivelEducacion = _nivelEducacionBlo.GetAll();
            ViewBag.profesion = _profesionBlo.GetAll();
            ViewBag.estadoCivil = _estadoCivilBlo.GetAll();
            ViewBag.ciudad = _ciudadBlo.GetAll();
            //Para direcciones
            ViewBag.tipoVivienda = _tipoViviendaBlo.GetAll();
            ViewBag.departamento = _departamentoBlo.GetAll();
            //Para referencias
            ViewBag.tipoReferencia = _tipoReferenciaBlo.GetAll();
            //Para informacion economica
            ViewBag.tipoPropiedad = _tipoPropiedadBlo.GetAll();
            ViewBag.tipoDireccion = _tipoDireccionBlo.GetAll();

            //Se usa para detalle del contacto
            Session["ContactoDirecciones"] = new List<crmContactoDireccion>();
            Session["ContactoReferencias"] = new List<crmContactoReferencia>();
            Session["ContactoInfEconomica"] = new List<crmContactoInformacionEco>();
            Session["ContactoArchivos"] = new List<crmContactoArchivos>();
            Session["idCampania"] = new long();

            return View();
        }

        #region Oportunidad

        /// <summary>
        /// Metodo para  llenar el grid 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOportunidad(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total = 0;
                var records = _oportunidadBlo.GetSolAsignadas(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_CREDITO_ASIGNADO, (long)Session["MyCodigoEmpleado"]);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        /// <summary>
        /// Metodo que se ejecuta cada minuto para notificar al usuario
        /// el número de alertas notificadas
        /// </summary>
        /// <returns>int cantidad de alertas notificadas</returns>
        [HttpPost]
        public JsonResult NotificarSolicitudes()
        {
            long cantidad = 0;

            try
            {
                cantidad = _oportunidadBlo.TotalAsingadas((long)Session["MyCodigoEmpleado"]);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error al obtener cantidad de alertas notificadas");
            }

            return Json(new { cantidad }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreditoSinAsignar(int id)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            crmContacto contacto = new crmContacto();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _oportunidadBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                contacto = _contactoBlo.GetContactoXIdOportunidad(id);
                if (contacto.Id > 0)
                {
                    Oportunidad = _oportunidadBlo.GetById(id);
                    Oportunidad.Estado = crmOportunidad.ESTADO_CREDITO_SINASIGNAR;
                    Oportunidad.FechaVenta = DateTime.Now;
                    _oportunidadBlo.Save(Oportunidad);
                }
                else
                {
                    mensaje = "Debe completar la ficha del cliente.";
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveResolucion(crmOportunidad data)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _oportunidadBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());
                if (data.Id != 0)
                {
                    Oportunidad = _oportunidadBlo.GetById(data.Id);
                    Oportunidad.FechaModifico = DateTime.Now;
                    Oportunidad.IdUsuarioModifico = GetIdUsuario();
                }

                Oportunidad.Estado = data.Estado;
                Oportunidad.ComentarioAnalisis = data.ComentarioAnalisis;
                Oportunidad.FechaVenta = DateTime.Now;
                _oportunidadBlo.Save(Oportunidad);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Contacto

        [HttpPost]
        public JsonResult Save(crmContacto data)
        {

            string mensaje = PropertiesBlo.msgExito;

            try
            {
                _contactoBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());

                //guardar datos
                _contactoBlo.SaveContacto(data, (List<crmContactoDireccion>)Session["ContactoDirecciones"],
                    (List<crmContactoReferencia>)Session["ContactoReferencias"], (List<crmContactoInformacionEco>)Session["ContactoInfEconomica"], (List<crmContactoArchivos>)Session["ContactoArchivos"],
                    GetEmpresa(), GetIdUsuario(), GetSucursal());

                //limpiar variables
                Session["ContactoDirecciones"] = new List<crmContactoDireccion>();
                Session["ContactoReferencias"] = new List<crmContactoReferencia>();
                Session["ContactoInfEconomica"] = new List<crmContactoInformacionEco>();
                Session["ContactoArchivos"] = new List<crmContactoArchivos>();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }


            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Para editar Ficha de Cliente
        /// </summary>
        /// <param name="IdOportunidad">Identificador de Oportunidad</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDatosContacto(long IdOportunidad = 0, int IdTipoVenta = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContacto contacto = new crmContacto();
            IQueryable<dynamic> lista = null;
            bool isCampania = false;
            List<InvProductoPartes> partes = new List<InvProductoPartes>();

            try
            {
                if (IdOportunidad > 0)
                {
                    //datos de oportunidad
                    var oportunidad = _oportunidadBlo.GetById(IdOportunidad);
                    //datos del contacto
                    contacto = _contactoBlo.GetContactoXIdOportunidad(IdOportunidad);
                    contacto.IdOportunidad = IdOportunidad;
                    contacto.IdTipoVenta = IdTipoVenta;

                    if (contacto.Id > 0)
                    {
                        Session["ContactoDirecciones"] = _contactoDireccionBlo.GetDatosDetalle("IdContacto", contacto.Id);
                        Session["ContactoReferencias"] = _contactoReferenciaBlo.GetDatosDetalle("IdContacto", contacto.Id);
                        Session["ContactoInfEconomica"] = _contactoInformacionEcoBlo.GetDatosDetalle("IdContacto", contacto.Id);
                        Session["ContactoArchivos"] = _contactoArchivosBlo.GetDatosDetalle("IdContacto", contacto.Id);
                        //si una actualizacion cargar las partes del producto guardado
                        partes = _campaniaProdPartesBlo.GetProductoPartes(contacto.CondIdProducto.Value, new long[0]).Where(x => x.IdSucursal == GetSucursal()).ToList();
                    }
                    else
                    {
                        Session["ContactoDirecciones"] = new List<crmContactoDireccion>();
                        Session["ContactoReferencias"] = new List<crmContactoReferencia>();
                        Session["ContactoInfEconomica"] = new List<crmContactoInformacionEco>();
                        Session["ContactoArchivos"] = new List<crmContactoArchivos>();
                    }

                    //obtener datos de campaña de mercadeo
                    if (oportunidad.IdCampania != null && oportunidad.OrigenConctacto.ToString().Contains("Campaña"))
                    {
                        var campania = _campaniaBlo.GetById(oportunidad.IdCampania);

                        //validar si la campaña aplica para la sucursal actual
                        var sucursales = _campaniaSucursalBlo.GetDatosDetalle("IdCampania", oportunidad.IdCampania).Where(x => x.IdSucursalCampania == GetSucursal());
                        if (sucursales.Any())
                        {
                            isCampania = true;
                            Session["idCampania"] = oportunidad.IdCampania.Value;

                            lista = _productosBlo.GetProductosCampania(GetEmpresa(), oportunidad.IdCampania.Value);

                            //establecer campos que dependen de la campaña
                            if (contacto.Id == 0)
                            {
                                contacto.CondIdMarca = campania.IdInvMarca;
                                contacto.CondIdNivelPrecio = campania.IdInvNivelPrecio;
                                contacto.CondTipoDescuento = campania.TipoDescuento;
                                contacto.CondTipoPrima = "Valor";
                                contacto.CondValorDescuento = 0;
                                contacto.CondvalorPrima = 0;
                                contacto.CondGarantia = 0;
                                contacto.CondPrimerCuota = 1;
                            }
                        }
                        else //si no aplica la campaña dejar valores por default
                        {
                            isCampania = false;
                            Session["idCampania"] = 0;
                            lista = _productosBlo.GetProductosMarca(GetEmpresa(), 0);

                            //establecer campos de forma predeterminada (sin campaña)
                            if (contacto.Id == 0)
                            {
                                contacto.CondIdMarca = 0;
                                contacto.CondIdNivelPrecio = 1;
                                contacto.CondTipoDescuento = "Valor";
                                contacto.CondTipoPrima = "Valor";
                                contacto.CondValorDescuento = 0;
                                contacto.CondvalorPrima = 0;
                                contacto.CondGarantia = 0;
                                contacto.CondPrimerCuota = 1;
                            }
                        }
                    }
                    else
                    {
                        isCampania = false;
                        Session["idCampania"] = 0;
                        lista = _productosBlo.GetProductosMarca(GetEmpresa(), 0);

                        //establecer campos de forma predeterminada (sin campaña)
                        if (contacto.Id == 0)
                        {
                            contacto.CondIdMarca = 0;
                            contacto.CondIdNivelPrecio = 1;
                            contacto.CondTipoDescuento = "Valor";
                            contacto.CondTipoPrima = "Valor";
                            contacto.CondValorDescuento = 0;
                            contacto.CondvalorPrima = 0;
                            contacto.CondGarantia = 0;
                            contacto.CondPrimerCuota = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje, contacto, isCampania, lista, partes }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ValidaCondicionesCred(long idContacto, bool validaCondicionesCred)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContacto contacto = new crmContacto();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                contacto = _contactoBlo.GetById(idContacto);
                contacto.FechaValidaCondicionesCred = DateTime.Now;
                contacto.ValidaCondicionesCred = validaCondicionesCred;
                _contactoBlo.Save(contacto);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ValidaDatosCliente(long idContacto, bool validaDatosCliente)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContacto contacto = new crmContacto();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                contacto = _contactoBlo.GetById(idContacto);
                contacto.ValidaDatosCliente = validaDatosCliente;
                contacto.FechaValidaDatosCliente = DateTime.Now;
                _contactoBlo.Save(contacto);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ValidaDatosConyuge(long idContacto, bool validaDatosConyuge)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContacto contacto = new crmContacto();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                contacto = _contactoBlo.GetById(idContacto);
                contacto.ValidaDatosConyuge = validaDatosConyuge;
                contacto.FechaValidaDatosConyuge = DateTime.Now;
                _contactoBlo.Save(contacto);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ValidaActividadEco(long idContacto, bool validaActividadEco)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContacto contacto = new crmContacto();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                contacto = _contactoBlo.GetById(idContacto);
                contacto.ValidaActividadEco = validaActividadEco;
                contacto.FechaValidaActividadEco = DateTime.Now;
                _contactoBlo.Save(contacto);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Direcciones

        [HttpGet]
        public JsonResult GetDirecciones()
        {
            try
            {
                var records = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                    .Select(x => new
                    {
                        x.Id,
                        x.IdDepartamento,
                        Departamento = _departamentoBlo.GetById(x.IdDepartamento).EstadoDes,
                        x.IdMunicipio,
                        Municipio = _ciudadBlo.GetById(x.IdMunicipio).CiudadesDes,
                        x.Direccion,
                        x.DirReferencia,
                        x.IdTipoVivienda,
                        TipoVivienda = _tipoViviendaBlo.GetById(x.IdTipoVivienda).TipoVivienda,
                        x.IdTipoDireccion,
                        x.TiempoResidenciaMeses,
                        x.Comentario,
                        x.Valida,
                        x.FechaValida
                    });

                return Json(new { records }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpPost]
        public JsonResult DireccionValida(long id, bool? valida = null)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoDireccion datos = new crmContactoDireccion();
            try
            {
                if (id != 0)
                {
                    datos = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                           .Where(x => x.Id == id)
                           .FirstOrDefault();

                    Session["ContactoDirecciones"] = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                        .Where(x => x.Id != id)
                        .ToList();

                    datos.Valida = valida == null ? true : !valida;
                    datos.FechaValida = DateTime.Now;

                    ((List<crmContactoDireccion>)Session["ContactoDirecciones"]).Add(datos);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgregarDireccion(crmContactoDireccion data)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (data.Id != 0)
                {
                    var direccion = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                         .Where(x => x.Id == data.Id)
                         .FirstOrDefault();

                    data.Valida = direccion.Valida;
                    data.FechaValida = direccion.FechaValida;

                    Session["ContactoDirecciones"] = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                        .Where(x => x.Id != data.Id)
                        .ToList();
                }
                else
                {

                    if (((List<crmContactoDireccion>)Session["ContactoDirecciones"]).Any())
                        data.Id = ((List<crmContactoDireccion>)Session["ContactoDirecciones"]).OrderByDescending(c => c.Id).First().Id + 1;
                    else
                        data.Id = 1;
                }

                ((List<crmContactoDireccion>)Session["ContactoDirecciones"]).Add(data);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveDireccion(int id = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoDireccion producto = new crmContactoDireccion();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());

                Session["ContactoDirecciones"] = ((List<crmContactoDireccion>)Session["ContactoDirecciones"])
                    .Where(x => x.Id != id)
                    .ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Referencias

        [HttpGet]
        public JsonResult GetReferencias()
        {
            try
            {
                var records = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                    .Select(x => new
                    {
                        x.Id,
                        x.Nombres,
                        x.Apellidos,
                        x.Parentesco,
                        x.Telefono,
                        x.IdTipoReferencia,
                        x.Valida,
                        x.FechaValida,
                        TipoReferencia = _tipoReferenciaBlo.GetById(x.IdTipoReferencia).TipoReferencia
                    });

                return Json(new { records }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpPost]
        public JsonResult ReferenciaValida(long id, bool? valida = null)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoReferencia datos = new crmContactoReferencia();
            try
            {
                if (id != 0)
                {
                    datos = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                           .Where(x => x.Id == id)
                           .FirstOrDefault();

                    Session["ContactoReferencias"] = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                        .Where(x => x.Id != id)
                        .ToList();

                    datos.Valida = valida == null ? true : !valida;
                    datos.FechaValida = DateTime.Now;

                    ((List<crmContactoReferencia>)Session["ContactoReferencias"]).Add(datos);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AgregarReferencia(crmContactoReferencia data)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (data.Id != 0)
                {
                    var referencia = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                         .Where(x => x.Id == data.Id)
                         .FirstOrDefault();

                    data.Valida = referencia.Valida;
                    data.FechaValida = referencia.FechaValida;

                    Session["ContactoReferencias"] = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                        .Where(x => x.Id != data.Id)
                        .ToList();
                }
                else
                {

                    if (((List<crmContactoReferencia>)Session["ContactoReferencias"]).Any())
                        data.Id = ((List<crmContactoReferencia>)Session["ContactoReferencias"]).OrderByDescending(c => c.Id).First().Id + 1;
                    else
                        data.Id = 1;
                }

                ((List<crmContactoReferencia>)Session["ContactoReferencias"]).Add(data);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveReferencia(int id = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoReferencia producto = new crmContactoReferencia();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());

                Session["ContactoReferencias"] = ((List<crmContactoReferencia>)Session["ContactoReferencias"])
                    .Where(x => x.Id != id)
                    .ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Información Económica

        [HttpGet]
        public JsonResult GetInfoEconomica()
        {
            try
            {
                var records = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                    .Select(x => new
                    {
                        x.Id,
                        x.Nombre,
                        x.Valor,
                        x.Descripcion,
                        x.IdTipoPropiedad,
                        TipoPropiedad = _tipoPropiedadBlo.GetById(x.IdTipoPropiedad).TipoPropiedad,
                        x.Valida,
                        x.FechaValida
                    });

                return Json(new { records }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpPost]
        public JsonResult InformacionEcoValida(long id, bool? valida = null)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoInformacionEco datos = new crmContactoInformacionEco();
            try
            {
                if (id != 0)
                {
                    datos = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                           .Where(x => x.Id == id)
                           .FirstOrDefault();

                    Session["ContactoInfEconomica"] = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                        .Where(x => x.Id != id)
                        .ToList();

                    datos.Valida = valida == null ? true : !valida;
                    datos.FechaValida = DateTime.Now;

                    ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"]).Add(datos);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult AgregarInfoEconomica(crmContactoInformacionEco data)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (data.Id != 0)
                {
                    var infoEco = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                         .Where(x => x.Id == data.Id)
                         .FirstOrDefault();

                    data.Valida = infoEco.Valida;
                    data.FechaValida = infoEco.FechaValida;

                    Session["ContactoInfEconomica"] = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                        .Where(x => x.Id != data.Id)
                        .ToList();
                }
                else
                {

                    if (((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"]).Any())
                        data.Id = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"]).OrderByDescending(c => c.Id).First().Id + 1;
                    else
                        data.Id = 1;
                }

                ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"]).Add(data);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveInfoEconomica(int id = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmContactoInformacionEco producto = new crmContactoInformacionEco();
            try
            {
                _contactoDireccionBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());

                Session["ContactoInfEconomica"] = ((List<crmContactoInformacionEco>)Session["ContactoInfEconomica"])
                    .Where(x => x.Id != id)
                    .ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Validaciones

        [HttpPost]
        public JsonResult GetProductosClaseMarca(long idMarca = 0)
        {
            //idMarca 0 = todas las marcas
            //idClase 1 = motos
            IQueryable<dynamic> lista = null;

            if (Convert.ToInt64(Session["idCampania"]) > 0)
            {
                lista = _productosBlo.GetProductosCampania(GetEmpresa(), Convert.ToInt64(Session["idCampania"]));
            }
            else
            {
                lista = _productosBlo.GetProductosMarca(GetEmpresa(), idMarca);
            }

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDatosProducto(long idProducto, long idNivelPrecio)
        {

            crmContacto datos = new crmContacto();
            List<InvProductoPartes> partes = new List<InvProductoPartes>();
            bool isCampania = false;

            if (Convert.ToInt64(Session["idCampania"]) > 0)
            {
                isCampania = true;
                var campania = _campaniaBlo.GetById(Convert.ToInt64(Session["idCampania"]), true);
                if (campania.crmCampaniaProducto.Where(x => x.IdProducto == idProducto).Any())
                {
                    List<long> idsPartes = campania.crmCampaniaProducto
                          .Where(x => x.IdProducto == idProducto)
                          .FirstOrDefault()
                          .crmCampaniaProdPartes
                          .Select(x => x.IdInvProductoPartes).ToList();

                    partes = _campaniaProdPartesBlo.GetProductoPartes(idProducto, new long[0])
                        .Where(x => (idsPartes.Any() ? idsPartes.Contains(x.Id) : 1 == 1) && x.IdSucursal == GetSucursal())
                        .ToList();

                    var datosProdCampania = campania.crmCampaniaProducto.Where(x => x.IdProducto == idProducto).FirstOrDefault();
                    datos.CondTipoDescuento = datosProdCampania.TipoDescuento;
                    datos.CondValorDescuento = datosProdCampania.ValorDescuento;
                    datos.CondPrecioActual = datosProdCampania.PrecioActual;
                    datos.CondPrecioNuevo = datosProdCampania.PrecioNuevo;
                    datos.CondTipoPrima = datosProdCampania.TipoPrima;
                    datos.CondvalorPrima = datosProdCampania.valorPrima;
                    datos.CondGarantia = datosProdCampania.Garantia;
                    datos.CondPrimerCuota = datosProdCampania.PrimerCuota;
                    //regalias
                    if (datosProdCampania.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").Any())
                        datos.CondIdProductoParteServio = datosProdCampania.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").FirstOrDefault().IdProducto;
                    if (datosProdCampania.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").Any())
                        datos.CondIdProductoAccesorio = datosProdCampania.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").FirstOrDefault().IdProducto;
                }
            }
            else
            {
                InvProducto producto = _productosBlo.GetDatosProducto(GetEmpresa(), idProducto, idNivelPrecio);
                datos.CondPrecioActual = producto.Precio;
                partes = _campaniaProdPartesBlo.GetProductoPartes(idProducto, new long[0]).Where(x => x.IdSucursal == GetSucursal()).ToList();
            }

            return Json(new { datos, partes, isCampania }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// El pago mensual (capital inicial + interés) necesario para pagar un préstamo de $275.000 a 25 años e intereses del 6,5 % anual,
        /// con pagos que vencen a fin de mes:
        /// Formula financiera de anualidad (función Excel):A = PAGO(i ; N ; -P )	
        /// </summary>
        [HttpPost]
        public JsonResult CalculoCuota(long idCondicionPago, double monto)
        {
            double montoCuota = 0;
            if (idCondicionPago > 0 && monto > 0)
            {
                //Application application = new Application();
                //double pTasaInteresPeriodica = 60 / 100;
                //double pNumeroDeAnualidades = _condicionPagoBlo.GetCondicionesPago(GetEmpresa()).Where(x => x.Id == idCondicionPago).FirstOrDefault().Agregar;
                //montoCuota = application.WorksheetFunction.Pmt(pTasaInteresPeriodica / 12, pNumeroDeAnualidades, -monto);
                //application.Quit();

                var tasa = _tasaInteresBlo.GetDefault();
                double valor = Convert.ToDouble(tasa.Id > 0 ? tasa.TasaInteresEfectiva : 0);
                double porcentaje = 100.00;
                double pTasaInteresPeriodica = valor / porcentaje;
                double pNumeroDeAnualidades = _condicionPagoBlo.GetCondicionesPago(GetEmpresa()).Where(x => x.Id == idCondicionPago).FirstOrDefault().Agregar;
                montoCuota = Financial.Pmt(pTasaInteresPeriodica / 12, pNumeroDeAnualidades, -monto);
            }

            return Json(new { montoCuota });
        }

        /// <summary>
        /// Devuelve el pago de intereses para un período determinado para una inversión basada en pagos periódicos y constantes y una tasa de interés constante.
        /// Formula de amortización mensual (función Excel):A = PAGOINT(i; 1; n; -P) 
        /// </summary>
        [HttpPost]
        public double CalculoAmortizacion(long idCondicionPago, double monto)
        {
            if (idCondicionPago > 0 && monto > 0)
            {
                Application application = new Application();
                double pTasaInteresPeriodica = 60 / 100;
                double pNumeroDeAnualidades = _condicionPagoBlo.GetCondicionesPago(GetEmpresa()).Where(x => x.Id == idCondicionPago).FirstOrDefault().Agregar;
                return application.WorksheetFunction.Ipmt(pTasaInteresPeriodica / 12, 1, pNumeroDeAnualidades, -monto);
            }
            else
            {
                return 0;
            }
        }

        #endregion


        #region  Subir archivos

        /// <summary>
        /// OBTENER LISTA DE DOCUMENTOS ADJUNTOS DE LA VARIABLE  DE SESION ////
        /// </summary>      
        public JsonResult GetAdjuntos()
        {
            try
            {
                var records = ((List<crmContactoArchivos>)Session["ContactoArchivos"])
                    .Select(x => new
                    {
                        x.Id,
                        x.Nombre,
                        x.Tipo,
                    });

                return Json(new { records }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }


        /// <summary>
        /// ELIMINAR DOCUMENTO DE  LA VARIABLE  DE SESION ///////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RemoveAdjuntos(int id)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _contactoArchivosBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());

                Session["ContactoArchivos"] = ((List<crmContactoArchivos>)Session["ContactoArchivos"])
                    .Where(x => x.Id != id)
                    .ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// GUARDAR DOCUMENTO EN LA VARIABLE  DE SESION EN FORMATO BINARIO ////
        /// </summary>
        /// <param name="Archivos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveAdjuntos(HttpPostedFileBase Archivos)
        {
            crmContactoArchivos ArchivoAdjunto = new crmContactoArchivos();
            string mensaje = PropertiesBlo.msgExito;
            try
            {

                String ExtensionArchivo = Path.GetExtension(Archivos.FileName).ToUpper();


                if (ExtensionArchivo == ".PDF" || ExtensionArchivo == ".DOC" || ExtensionArchivo == ".DOCX" || ExtensionArchivo == ".XLS" || ExtensionArchivo == ".XLSX" || ExtensionArchivo == ".PNG" || ExtensionArchivo == ".JPG" || ExtensionArchivo == ".GIF")
                {
                    if (((List<crmContactoArchivos>)Session["ContactoArchivos"]).Any())
                        ArchivoAdjunto.Id = ((List<crmContactoArchivos>)Session["ContactoArchivos"]).OrderByDescending(c => c.Id).First().Id + 1;
                    else
                        ArchivoAdjunto.Id = 1;


                    Stream str = Archivos.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] Adjunto = Br.ReadBytes((Int32)str.Length);

                    ArchivoAdjunto.Nombre = Archivos.FileName;
                    ArchivoAdjunto.Archivo = Adjunto;
                    ArchivoAdjunto.Tipo = ExtensionArchivo;

                    ((List<crmContactoArchivos>)Session["ContactoArchivos"]).Add(ArchivoAdjunto);
                }
                else
                {
                    mensaje = "Formato de Archivo no válido. Los tipos de archivo permitidos son: .PDF, .DOC, .DOCX, .XLS, .XLSX, .PNG, .JPEG,.JPG, .GIF";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// DESCARGAR DOCUMENTO VINCULADO A UN CONTACTO//
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>       
        public FileResult DescargarArchivo(long id)
        {
            crmContactoArchivos archivo = new crmContactoArchivos();
            try
            {
                archivo = ((List<crmContactoArchivos>)Session["ContactoArchivos"]).Where(x => x.Id == id).FirstOrDefault();

                return File(archivo.Archivo, archivo.Tipo, archivo.Nombre);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }

        }


        #endregion
    }
}