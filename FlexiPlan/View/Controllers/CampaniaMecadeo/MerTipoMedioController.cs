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
   public class  MerTipoMedioController  : BaseController
   {
       /// <summary>
       /// instancia de la interfas para poder hacer el CRUD
       /// </summary>
       /// <returns></returns>
       [Inject]
       public ITipoMedioBlo _tipoMedioBlo  { get; set; }
       
       public ActionResult Index()
       {
            return View();
       }
       
       /// <summary>
       /// Metodo para  llenar el grid 
        /// </summary>
       /// <returns></returns>
       [HttpGet]
       public JsonResult GetTipoMedio(int? page, int? limit, string sortBy, string direction, string searchString = null)
       {
           try
             {
                  int total = 0;
                  var records = _tipoMedioBlo.GetDatosGrid(out total, page, limit, sortBy, direction);
       
                  return Json(new { records, total }, JsonRequestBehavior.AllowGet);
              }
              catch (Exception ex)
              {
                  log.Error(ex);
                  throw new System.ArgumentException("Error obteniendo lista los datos");
              }
       }
       
       [HttpPost]
       public JsonResult Save(crmTipoMedio data)
       {
            crmTipoMedio TipoMedio = new crmTipoMedio();
            string mensaje = PropertiesBlo.msgExito;
            try
               {
                _tipoMedioBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());
                if (data.Id != 0)
                   TipoMedio = _tipoMedioBlo.GetById(data.Id);    
                
                 TipoMedio.TipoMedio= data.TipoMedio;
        
             _tipoMedioBlo.Save(TipoMedio);

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
                 _tipoMedioBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());
                 _tipoMedioBlo.Remove(id);
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
