using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blo.Seguridad;
using System.Text;
using System.Web.Security;
using hbehr.AdAuthentication;
using System.Configuration;
using Model;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using Ninject;
using Microsoft.VisualBasic;

namespace View.Controllers.Seguridad
{
    public class LoginController : BaseController
    {
        /// <summary>
        /// Propiedades que representan el objeto principal de acceso a logica del negocio.
        /// </summary>
        [Inject]
        public IUsuarioBlo _usuario { get; set; }
        [Inject]
        public IParametroBlo _parametroBlo { get; set; }
        [Inject]
        public IOpcionBlo _opcionBlo { get; set; }
        [Inject]
        public IEmpresaBlo _empresaBlo { get; set; }
        [Inject]
        public ISucursalBlo _sucursalesBlo { get; set; }
        [Inject]
        public IPeriodoBlo _periodoBlo { get; set; }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.empresa = _empresaBlo.GetAll();

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(string user, string pass, long idEmpresa)
        {
            long idSucursal = 0;
            long idPeriodo = 0;
            Periodo periodo = new Periodo();

            ViewBag.Error = null;
            try
            {
                _parametroBlo.DatabaseIsValid();

                var datos = _usuario.ValidarUsuario(user, Encriptar(pass), idEmpresa);

                if (datos.Any())
                {
                    if (datos.FirstOrDefault().PerfilEnc == null)
                        throw new Exception("Usted no tiene asignado un perfil.");
                    if (!datos.FirstOrDefault().AccesoUsuario.Any())
                        throw new Exception("Usted no tiene acceso a esta aplicación.");

                    FormsAuthentication.SetAuthCookie(user, true);

                    Session["MyIdUser"] = datos.FirstOrDefault().id;
                    Session["MyCodeUser"] = datos.FirstOrDefault().Codigo;
                    Session["MyCodePerfil"] = datos.FirstOrDefault().idperfilenc;
                    Session["MyNombre"] = datos.FirstOrDefault().NombreCompleto;
                    Session["MyPerfil"] = datos.FirstOrDefault().PerfilEnc.PerfilDes;
                    Session["MyCodeEmpresa"] = idEmpresa;
                    Session["MyDatosUsuario"] = datos.FirstOrDefault();
                    Session["MyEmpresa"] = _empresaBlo.GetById(idEmpresa).EmpresaDes;
                    Session["MyDatosSucursales"] = _sucursalesBlo.GetSucursalxEmpresa(idEmpresa);
                    Session["MyDatosPeriodos"] = _periodoBlo.GetPeriodoActivosxEmpresa(idEmpresa);
                    Session["MyCodigoEmpleado"] = datos.FirstOrDefault().IdEmpleado;
                 

                    //Seleccionar periodo por defecto
                    if (datos.FirstOrDefault().AccesoUsuario.FirstOrDefault().IdPeriodoSeleccionado != 0)
                        idPeriodo = datos.FirstOrDefault().AccesoUsuario.FirstOrDefault().IdPeriodoSeleccionado;
                    else
                        idPeriodo = ((List<Periodo>)Session["MyDatosPeriodos"]).FirstOrDefault().Id;
                    //Seleccionar Sucursal por defecto
                    if (datos.FirstOrDefault().AccesoUsuario.FirstOrDefault().IdSucursalSeleccionada != 0)
                        idSucursal = datos.FirstOrDefault().AccesoUsuario.FirstOrDefault().IdSucursalSeleccionada;
                    else
                        idSucursal = ((List<Sucursal>)Session["MyDatosSucursales"]).FirstOrDefault().Id;

                    Session["MyCodigoSucursales"] = idSucursal;
                    Session["MyCodigoPeriodos"] = idPeriodo;
                    Session["MySucursal"] = _sucursalesBlo.GetById(idSucursal).SucursalDes;
                    periodo = _periodoBlo.GetById(idPeriodo, true);
                    Session["MyPeriodo"] = "-" + periodo.Meses.Mes + " " + periodo.Ejercicio.EjercicioDes + "-";

                    LoadMenu(datos.FirstOrDefault().idperfilenc, idEmpresa);

                    return RedirectToAction("Index", "Home");
                }
                else
                    throw new Exception("El usuario o contraseña son incorrectos.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                FormsAuthentication.SignOut();
                ViewBag.Error = ex.Message;
                ViewBag.empresa = _empresaBlo.GetAll();
                return View();
            }
        }


        [AllowAnonymous]
        private void LoadMenu(long perfil, long idEmpresa)
        {
            try
            {
                StringBuilder mBuilder = new StringBuilder();
                var opciones = _opcionBlo.GetOpcionPorPerfil(perfil, idEmpresa);


                if (!opciones.Any())
                {
                    throw new System.ArgumentException("No tiene opciones asignadas a su perfil");
                }
                else
                {
                    mBuilder.Append(@"<ul class=""sidebar-menu"">");
                    mBuilder.Append(@"<li class=""header"">MENU PRINCIPAL</li>");

                    //modulos
                    foreach (var m in opciones.Where(x => x.opciontipo == "MODULO").OrderBy(x => x.Posicion))
                    {
                        if (m.URL != "#")
                        {
                            mBuilder.Append(@"<li>");
                            mBuilder.Append(@"<a href=" + m.URL + ">");
                            mBuilder.Append(@"<i class=""fa fa-th""></i>");
                            mBuilder.Append(@"<span>" + m.opciondes + @"</span>");
                            mBuilder.Append(@"</a>");
                            mBuilder.Append(@"</li>");
                        }
                        else
                        {
                            mBuilder.Append(@"<li class=""treeview"">");
                            mBuilder.Append(@"<a href=" + m.URL + ">");
                            mBuilder.Append(@"<i class=""fa fa-th""></i>");
                            mBuilder.Append(@"<i class=""fa fa-angle-left pull-right""></i>");
                            mBuilder.Append(@"<span>" + m.opciondes + @"</span>");
                            mBuilder.Append(@"</a>");
                            mBuilder.Append(@"<ul class=""treeview-menu"">");

                            //opciones x modulo
                            //1 nivel
                            foreach (var o in opciones.Where(x => x.opciontipo == "BOTON" && x.idpadre == m.id).OrderBy(x => x.Posicion))
                            {
                                mBuilder.Append(@"<li><a href="""
                                                + o.URL + @"""><i class=""fa fa-circle-o""></i>"
                                                + o.opciondes
                                                + @"</a>");

                            }

                            mBuilder.Append(@"</ul>");
                            mBuilder.Append(@"</li>");
                        }
                    }

                    mBuilder.Append("</ul>");
                    Session["bootstrapMenu"] = mBuilder.ToString();
                }


            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException(ex.Message);
            }
        }

        [Autorizacion]
        public ActionResult Salir()
        {
            try
            {
                FormsAuthentication.SignOut();

                Session["MyCodeUser"] = null;
                Session["MyCodePerfil"] = null;
                Session["MyNombre"] = null;
                Session["MyPerfil"] = null;
                Session["MyCodeEmpresa"] = null;
                Session["MyDatosUsuario"] = null;
                Session["MyEmpresa"] = null;
                Session["MyDatosSucursales"] = null;
                Session["MyDatosPeriodos"] = null;
                Session["MyCodigoSucursales"] = null;
                Session["MyCodigoPeriodos"] = null;
                Session["MySucursal"] = null;
                Session["MyPeriodo"] = null;
                Session["MyIdUser"] = null;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return RedirectToAction("Index", "Login");
        }

        private string Encriptar(string Cadena)
        {
            int X;
            string Letr;
            string Encriptar = "";
            for (X = 1; X <= Strings.Len(Cadena); X++)
            {
                Letr = Strings.Mid(Cadena, X, 1);
                Encriptar = Encriptar + Strings.Chr((Strings.Asc(Letr) - 1) * 2);
            }
            return Encriptar;
        }


        private string DesEncriptar(string Cadena)
        {

            int X;
            string Letr;
            string DesEncriptar = "";
            for (X = 1; X <= Strings.Len(Cadena); X++)
            {
                Letr = Strings.Mid(Cadena, X, 1);
                DesEncriptar = DesEncriptar + Strings.Chr((Strings.Asc(Letr) / (int)2) + 1);
            }
            return DesEncriptar;
        }

    }
}