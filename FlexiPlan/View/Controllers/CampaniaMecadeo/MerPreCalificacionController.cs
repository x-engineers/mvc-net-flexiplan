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

namespace View.Controllers.CampaniaMecadeo
{
    [NoCache]
    [Autorizacion]
    public class MerPreCalificacionController : BaseController
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
                var records = _oportunidadBlo.GetOportunidades(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_PRECALIFICACION);

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
            try
            {
                _oportunidadBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());
                if (data.Id != 0)
                {
                    Oportunidad = _oportunidadBlo.GetById(data.Id);
                    Oportunidad.FechaModifico = DateTime.Now;
                    Oportunidad.IdUsuarioModifico = GetIdUsuario();
                }
                
                if(data.Calificacion== crmOportunidad.ESTADO_DENEGADO)
                    Oportunidad.Estado = crmOportunidad.ESTADO_DENEGADO;
                else
                    Oportunidad.Estado = crmOportunidad.ESTADO_SIN_ASIGNAR;

                Oportunidad.Calificacion = data.Calificacion;
                Oportunidad.ComentarioCalificacion = data.ComentarioCalificacion;
         
                _oportunidadBlo.Save(Oportunidad);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}