using Model;
using Blo.Seguridad;
using Microsoft.Reporting.WebForms;
using Ninject;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Reflection;
using System.IO;
using Blo.Properties;
using System.DirectoryServices;
using System.Configuration;
using System.Net;
using System.DirectoryServices.Protocols;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace View.Controllers
{
    /// <summary>
    /// Clase compartida para evitar replicar codigo
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Permite el seguimiento de errores
        /// </summary>
        public static readonly log4net.ILog log =
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Propiedad que representa el objeto principal de acceso a datos
        /// por medio de esta se prodra acceder a las funciones, procedimientos
        /// almecenados y vistas SQL
        /// </summary>
        public SQLBDEntities _SQLBDEntities = new SQLBDEntities();



        /// <summary>
        /// Propiedad que representa el objeto principal de acceso a logica del 
        /// negocio para la entidad IParametroBlo.
        /// </summary>
        private IParametroBlo _parametrosSegBlo;

        /// <summary>
        /// Propiedad que representa el objeto principal de acceso a logica del 
        /// negocio para la entidad IOpcionBlo.
        /// </summary>
        private IOpcionBlo _opcionBlo;

        /// <summary>
        /// Propiedad que representa el objeto principal de acceso a logica del 
        /// negocio para la entidad IOpcionBlo.
        /// </summary>
        private IAccesoUsuarioBlo _acceso;


        /// <summary>
        /// Inyeccion de dependencias al objeto de enlace a logica del negocio
        /// para el objeto IParametroBlo
        /// </summary>
        [Inject]
        public IParametroBlo parametrosSegBlo
        {
            get { return _parametrosSegBlo; }
            set { _parametrosSegBlo = value; }
        }

        /// <summary>
        /// Inyeccion de dependencias al objeto de enlace a logica del negocio
        /// para el objeto IOpcionBlo
        /// </summary>
        [Inject]
        public IOpcionBlo opcionBlo
        {
            get { return _opcionBlo; }
            set { _opcionBlo = value; }
        }

        /// <summary>
        /// Inyeccion de dependencias al objeto de enlace a logica del negocio
        /// para el objeto IAccesoUsuarioBlo
        /// </summary>
        [Inject]
        public IAccesoUsuarioBlo acceso
        {
            get { return _acceso; }
            set { _acceso = value; }
        }



        /// <summary>
        /// Valor inicial establecido para los select/dropdowlist 
        /// </summary>
        public string SELECCIONDEFAULT = "";


        public Usuario GetDatosUsuario()
        {
            return (Usuario)Session["MyDatosUsuario"];
        }

        public long GetIdUsuario()
        {
            return (long)Session["MyIdUser"];
        }

        public long GetRol()
        {
            return (long)Session["MyCodePerfil"];
        }

        public long GetEmpresa()
        {
            return (long)Session["MyCodeEmpresa"];
        }

        public long GetSucursal()
        {
            return (long)Session["MyCodigoSucursales"];
        }

        public long GetPeriodo()
        {
            return (long)Session["MyCodigoPeriodos"];
        }

        public long GetOpcion()
        {
            string path = Request.Url.AbsolutePath;
            path = "\\" + path.Split('/')[1];
            var opcion = _opcionBlo.GetOpcionPorURL(path);

            if (opcion != null)
                return opcion.id;
            else
                return 0;
        }

        [HttpPost]
        public JsonResult CambiarSucursal(long id)
        {
            AccesoUsuario accesoUsuario = new AccesoUsuario();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (id != 0)
                {
                    accesoUsuario = GetDatosUsuario().AccesoUsuario.Single();
                    accesoUsuario.IdSucursalSeleccionada = id;
                    _acceso.SaveNoTrack(accesoUsuario);

                    Session["MyCodigoSucursales"] = id;
                    Session["MySucursal"] = ((List<Sucursal>)Session["MyDatosSucursales"]).Where(x => x.Id == id).FirstOrDefault().SucursalDes;
                }
                else
                    throw new System.ArgumentException("El ID debe ser diferente de 0, favor validar");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CambiarPeriodo(long id)
        {
            AccesoUsuario accesoUsuario = new AccesoUsuario();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                if (id != 0)
                {
                    accesoUsuario = GetDatosUsuario().AccesoUsuario.Single();
                    accesoUsuario.IdPeriodoSeleccionado = id;
                    _acceso.SaveNoTrack(accesoUsuario);

                    Session["MyCodigoPeriodos"] = id;
                    var periodo = ((List<Periodo>)Session["MyDatosPeriodos"]).Where(x => x.Id == id).FirstOrDefault();
                    Session["MyPeriodo"] = "-" + periodo.Meses.Mes + " " + periodo.Ejercicio.EjercicioDes + "-";
                }
                else
                    throw new System.ArgumentException("El ID debe ser diferente de 0, favor validar");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo que permite obtener un parametro por su codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns> valor del parametro</returns>
        public string ObtenerParametro(string codigo)
        {
            string valor = null;
            try
            {
                valor = _parametrosSegBlo.GetParametroByCodigo(codigo).Valor;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error intentando obtener un parametro de Base de Datos");
            }
            return valor;
        }


        /// <summary>
        /// Permite descargar un reporte en diferentes formatos como PDF, Word y Excel
        /// </summary>
        /// <param name="nombre">Nombre del reporte</param>
        /// <param name="formato">Define si es PDF, Word ó Excel</param>
        /// <param name="parametros">Lista de parametros</param>
        /// <param name="query">Consulta</param>
        /// <param name="nombreDataSet">Nombre del Dataset usado en el Reporte</param>
        /// <param name="query2">Consulta 2 es opcional</param>
        /// <param name="nombreDataSet2">Es requerido solo si define Consulta 2</param>
        /// <param name="query3">Consulta 3 es opcional</param>
        /// <param name="nombreDataSet3">Es requerido solo si define Consulta 3</param>
        /// <param name="query4">Consulta 4 es opcional</param>
        /// <param name="nombreDataSet4">Es requerido solo si define Consulta 4</param>
        /// <param name="query5">Consulta 5 es opcional</param>
        /// <param name="nombreDataSet5">Es requerido solo si define Consulta 5</param>
        public void LoadReport(String nombre, string formato, List<ReportParameter> parametros,
        IEnumerable<dynamic> query, String nombreDataSet,
        IEnumerable<dynamic> query2 = null, String nombreDataSet2 = null,
        IEnumerable<dynamic> query3 = null, String nombreDataSet3 = null,
        IEnumerable<dynamic> query4 = null, String nombreDataSet4 = null,
        IEnumerable<dynamic> query5 = null, String nombreDataSet5 = null)
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer();

                reportViewer.SizeToReportContent = true;
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 90;
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.EnableExternalImages = true;
                reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\" + nombre + ".rdlc";
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet, query));


                if (query2 != null && nombreDataSet2 != null)
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet2, query2));
                if (query3 != null && nombreDataSet3 != null)
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet3, query3));
                if (query4 != null && nombreDataSet4 != null)
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet4, query4));
                if (query5 != null && nombreDataSet5 != null)
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource(nombreDataSet5, query5));


                //Agregando parametros al reporte
                foreach (var param in parametros) reportViewer.LocalReport.SetParameters(param);


                //Permite la descarga del reporte en diferentes formatos
                switch (formato.ToUpper())
                {
                    case "PDF":
                        ImprimirPDF(reportViewer, nombre);
                        break;
                    case "WORD":
                        ImprimirWord(reportViewer, nombre);
                        break;
                    case "EXCEL":
                        ImprimirExcel(reportViewer, nombre);
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error al cargar el Reporte: " + nombre);
            }
        }


        /// <summary>
        /// Metodo que permite descargar el reporte en formato PDF
        /// </summary>
        /// <param name="reporte">Objeto que contiene la definición del reporte</param>
        /// <param name="nombre">Nombre con el que se descarga el reporte</param>
        public void ImprimirPDF(ReportViewer reporte, string nombre)
        {
            try
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline;filename=" + nombre + ".pdf");
                Response.Buffer = true;
                Response.BinaryWrite(reporte.LocalReport.Render("PDF", null));
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error al imprimir en PDF el Reporte: " + nombre);
            }
        }


        /// <summary>
        /// Metodo que permite descargar el reporte en formato Word
        /// </summary>
        /// <param name="reporte">Objeto que contiene la definición del reporte</param>
        /// <param name="nombre">Nombre con el que se descarga el reporte</param>
        public void ImprimirWord(ReportViewer reporte, string nombre)
        {
            try
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment; filename=" + nombre + ".doc");
                Response.Buffer = true;
                Response.BinaryWrite(reporte.LocalReport.Render("WORD", null));
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error al imprimir en WORD el Reporte: " + nombre);
            }
        }


        /// <summary>
        /// Metodo que permite descargar el reporte en formato Excel
        /// </summary>
        /// <param name="reporte">Objeto que contiene la definición del reporte</param>
        /// <param name="nombre">Nombre con el que se descarga el reporte</param>
        public void ImprimirExcel(ReportViewer reporte, string nombre)
        {
            try
            {
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + nombre + ".xlsx");
                Response.Buffer = true;
                Response.BinaryWrite(reporte.LocalReport.Render("EXCELOPENXML", null));
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error al imprimir en Excel el Reporte: " + nombre);
            }
        }


        /// <summary>
        /// Limpia la cache del navegador 
        /// Evita problemas con el grid usado en esta aplicacion
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class NoCacheAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();

                base.OnResultExecuting(filterContext);
            }
        }
    }
}



