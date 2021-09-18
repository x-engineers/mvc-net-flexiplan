using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blo.Mercadeo;
using Blo.Properties;
using Model;
using Ninject;
using Blo;
using System.Reflection;

namespace View.Controllers.Mercadeo
{
    [NoCache]
    [Autorizacion]
    public class MerOportunidadController : BaseController
    {
        /// <summary>
        /// instancia de la interfas para poder hacer el CRUD
        /// </summary>
        /// <returns></returns>
        [Inject]
        public IOportunidadBlo _oportunidadBlo { get; set; }
        [Inject]
        public ITipoVentaBlo _tipoVentaBlo { get; set; }
        [Inject]
        public ICampaniaBlo _campaniaBlo { get; set; }
        [Inject]
        public IEmpleadoBlo _empleadoBlo { get; set; }
        [Inject]
        public ITipoMedioBlo _tipoMedioBlo { get; set; }
        [Inject]
        public IMedioContactoBlo _medioContactoBlo { get; set; }
        

        public ActionResult Index()
        {
            
            ViewBag.tipoMedio = _tipoMedioBlo.GetAll();
            ViewBag.vendedores = _empleadoBlo.GetVendedores(GetEmpresa());
            ViewBag.tipoVenta = _tipoVentaBlo.GetAll();
            ViewBag.campania = _campaniaBlo.GetListaActuales(GetEmpresa());
            return View();
        }

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
                var records = _oportunidadBlo.GetOportunidades(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_PENDIENTE);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpGet]
        public JsonResult GetOportunidadSinAsignar(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total = 0;
                var records = _oportunidadBlo.GetOportunidades(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_SIN_ASIGNAR);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpGet]
        public JsonResult GetOportunidadDenegadas(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total = 0;
                var records = _oportunidadBlo.GetOportunidades(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_DENEGADO);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }
        
        [HttpPost]
        public JsonResult Save(crmOportunidad data)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = PropertiesBlo.msgExito;
            string url = @"/Formulario";
            try
            {
                _oportunidadBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());
                if (data.Id != 0)
                {
                    Oportunidad = _oportunidadBlo.GetById(data.Id);
                    Oportunidad.FechaModifico = DateTime.Now;
                    Oportunidad.IdUsuarioModifico = GetIdUsuario();
                }
                else
                {
                    Oportunidad.FechaAgrego = DateTime.Now;
                    Oportunidad.IdUsuarioAgrego = GetIdUsuario();
                }

                Oportunidad.IdEmpresa = GetEmpresa();
                Oportunidad.Nombre = data.Nombre;
                Oportunidad.Telefono = data.Telefono;
                Oportunidad.Correo = data.Correo;
                Oportunidad.OrigenConctacto = data.OrigenConctacto;
                Oportunidad.DescripcionOrigen = data.DescripcionOrigen;
                Oportunidad.IdCampania = data.IdCampania;
                Oportunidad.IdTipoVenta = data.IdTipoVenta;
                Oportunidad.IdTipoMedio = data.IdTipoMedio;
                Oportunidad.IdMedioContacto = data.IdMedioContacto;
                Oportunidad.Estado = data.IdTipoVenta == 2 ? crmOportunidad.ESTADO_PENDIENTE : crmOportunidad.ESTADO_SIN_ASIGNAR;
                Oportunidad.Observacion = data.Observacion;
                Oportunidad.URLBuro = "";
                Oportunidad.URLActiva = true;
                Oportunidad.BuroNombres = "";
                Oportunidad.BuroApellidos = "";
                Oportunidad.BuroGenero = "M";
                Oportunidad.BuroDUI = "";
                Oportunidad.BuroNIT = "";
                Oportunidad.URLFechaEnvio = DateTime.Now;
                

                _oportunidadBlo.Save(Oportunidad);

                if (string.IsNullOrEmpty(Oportunidad.URLBuro) && Oportunidad.Id > 0)
                {
                    QSencriptadoCSharp.QueryString parametros = new QSencriptadoCSharp.QueryString();
                    parametros.Add("idOportunidad", Oportunidad.Id.ToString());
                    url += QSencriptadoCSharp.Encryption.EncryptQueryString(parametros).ToString();

                    Oportunidad.URLBuro = url;
                    _oportunidadBlo.Save(Oportunidad);
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
        public JsonResult Remove(int id)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _oportunidadBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());
                _oportunidadBlo.Remove(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Inactivo(int id)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _oportunidadBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                Oportunidad = _oportunidadBlo.GetById(id);
                Oportunidad.Estado = crmOportunidad.ESTADO_INACTIVO;
                _oportunidadBlo.Save(Oportunidad);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AsignarVendedaor(long[] ids,long IdEmpleado)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if(ids !=null && IdEmpleado > 0) { 
                _oportunidadBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                    foreach (var item in ids)
                    {
                        Oportunidad = _oportunidadBlo.GetById(item);
                        Oportunidad.Estado = "Asignado";
                        Oportunidad.IdEmpleado = IdEmpleado;
                        _oportunidadBlo.Save(Oportunidad);
                    }
               
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
        public JsonResult GetMedioContacto(long idTipoMedio)
        {
          List<crmMedioContacto> datos = _medioContactoBlo.GetMedio(idTipoMedio);
        
            return Json(new { datos }, JsonRequestBehavior.AllowGet);
        }

    }
}
