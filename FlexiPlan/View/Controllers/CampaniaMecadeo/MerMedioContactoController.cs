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
   public class  MerMedioContactoController  : BaseController
   {
       /// <summary>
       /// instancia de la interfas para poder hacer el CRUD
       /// </summary>
       /// <returns></returns>
       [Inject]
       public IMedioContactoBlo _medioContactoBlo  { get; set; }
        [Inject]
        public ITipoMedioBlo _tipoMedioBlo { get; set; }


        public ActionResult Index()
       {
            ViewBag.tipoMedio = _tipoMedioBlo.GetAll();
            return View();
       }
       
       /// <summary>
       /// Metodo para  llenar el grid 
        /// </summary>
       /// <returns></returns>
       [HttpGet]
       public JsonResult GetMedioContacto(int? page, int? limit, string sortBy, string direction, string searchString = null)
       {
           try
             {
                  int total = 0;
                var records = _medioContactoBlo.GetDatosGrid(out total, page, limit, sortBy, direction, true)
                    .Select(x => new {
                        x.Id,
                        x.MedioContacto,
                        x.IdTipoMedio,
                        tipoContacto= x.crmTipoMedio.TipoMedio

                    });
                 

             
                  return Json(new { records, total }, JsonRequestBehavior.AllowGet);
              }
              catch (Exception ex)
              {
                  log.Error(ex);
                  throw new System.ArgumentException("Error obteniendo lista los datos");
              }
       }
       
       [HttpPost]
       public JsonResult Save(crmMedioContacto data)
       {
            crmMedioContacto MedioContacto = new crmMedioContacto();
            string mensaje = PropertiesBlo.msgExito;
            try
               {
                _medioContactoBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());
                if (data.Id != 0)
                   MedioContacto = _medioContactoBlo.GetById(data.Id);
       
                 MedioContacto.IdTipoMedio= data.IdTipoMedio;
                 MedioContacto.MedioContacto= data.MedioContacto;
        
             _medioContactoBlo.Save(MedioContacto);
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
                 _medioContactoBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());
                 _medioContactoBlo.Remove(id);
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
