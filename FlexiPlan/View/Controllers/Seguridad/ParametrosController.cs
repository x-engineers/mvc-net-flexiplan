using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Blo.Seguridad;
using Blo.Properties;
using Ninject;

namespace View.Controllers.Seguridad
{
    [NoCache]
    [Autorizacion]
    public class ParametrosController : BaseController
    {
        /// <summary>
        /// Propiedades que representan el objeto principal de acceso a logica del negocio.
        /// </summary>
        [Inject]
        public IParametroBlo _parametrosBlo { get; set; }


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetParametros(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total;
                int start = (page.Value - 1) * limit.Value;
                var records = _parametrosBlo.GetAll().AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    records = records
                             .Where(x => (
                                    x.Codigo + " " +
                                    x.Descripcion + " " +
                                    x.Valor
                                    ).ToUpper().Contains(searchString.Trim().ToUpper())
                              ).AsQueryable();
                }

                total = records.Count();
                records = SortHelper.OrdenarGrid(records, sortBy, direction).Skip(start).Take(limit.Value);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }


        [HttpPost]
        public JsonResult Save(crmParametro data)
        {
            crmParametro parametro = new crmParametro();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _parametrosBlo.ValidarPermiso(GetRol(),GetOpcion(),crmParametro.EDITAR,GetEmpresa());

                if (data.Id != 0)
                {
                    parametro = _parametrosBlo.GetById(data.Id);
                    parametro.Valor = data.Valor;
                    _parametrosBlo.Save(parametro);
                }
                else
                    throw new System.ArgumentException("El ID debe ser diferente de 0, favor validar parametros");
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