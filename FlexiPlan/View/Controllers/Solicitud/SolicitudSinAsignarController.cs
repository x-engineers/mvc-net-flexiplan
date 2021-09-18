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
    public class SolicitudSinAsignarController : BaseController
    {
        /// <summary>
        /// instancia de la interfas para poder hacer el CRUD
        /// </summary>
        /// <returns></returns>
        [Inject]
        public IOportunidadBlo _oportunidadBlo { get; set; }
        [Inject]
        public IEmpleadoBlo _empleadoBlo { get; set; }
        [Inject]
        public IMedioContactoBlo _medioContactoBlo { get; set; }


        public ActionResult Index()
        {
            
            ViewBag.empleados = _empleadoBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());

            return View();
        }

        /// <summary>
        /// Metodo para  llenar el grid 
        /// </summary>
        /// <returns></returns>      
        [HttpGet]
        public JsonResult GetOportunidadSinAsignar(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total = 0;
                var records = _oportunidadBlo.GetOportunidades(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, crmOportunidad.ESTADO_CREDITO_SINASIGNAR);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpPost]
        public JsonResult AsignarVendedaor(long[] ids, long IdEmpleado)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (ids != null && IdEmpleado > 0)
                {
                    _oportunidadBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());
                    foreach (var item in ids)
                    {
                        Oportunidad = _oportunidadBlo.GetById(item);
                        Oportunidad.Estado = crmOportunidad.ESTADO_CREDITO_ASIGNADO;
                        Oportunidad.IdAnalista = IdEmpleado;
                        Oportunidad.FechaAnalisis = DateTime.Now;
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


        

    }
}