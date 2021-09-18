using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blo.Mercadeo;
using Ninject;
using Model;

namespace View.Controllers
{
    public class FormularioController : BaseController
    {
        /// <summary>
        /// instancia de la interfas para poder hacer el CRUD
        /// </summary>
        /// <returns></returns>
        [Inject]
        public IOportunidadBlo _oportunidadBlo { get; set; }

        public ActionResult Index()
        {
            bool urlValida = false;

            try
            {
                // 200 - ok
                // 404 - pagina no encontrada
                //throw new HttpException(404, "Página no encontrada");
                var parametro = QSencriptadoCSharp.Encryption.DecryptQueryString(QSencriptadoCSharp.QueryString.FromCurrent()).GetKey(0).TrimEnd(new Char[] { '\0' });
                var valor = QSencriptadoCSharp.Encryption.DecryptQueryString(QSencriptadoCSharp.QueryString.FromCurrent()).Get(parametro).TrimEnd(new Char[] { '\0' });

                if (parametro == "idOportunidad")
                {
                    long idOportunidad = long.Parse(valor);
                    if (idOportunidad > 0)
                    {
                        var oportunidad = _oportunidadBlo.GetById(idOportunidad);
                        if (oportunidad.URLBuro.Split("?".ToCharArray())[1] == Request.Url.AbsoluteUri.Split("?".ToCharArray())[1] &&
                            oportunidad.URLActiva == true && oportunidad.URLFechaEnvio.AddDays(1) >= DateTime.Now)
                        {
                            urlValida = true;
                            ViewBag.Id = oportunidad.Id;
                        }
                        else
                        {
                            oportunidad.URLActiva = false;
                            _oportunidadBlo.Save(oportunidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }


            if (!urlValida)
                return RedirectToAction("PaginaNoEncontrada");
            else
                return View();
        }

        [HttpPost]
        public JsonResult Save(crmOportunidad data)
        {
            crmOportunidad Oportunidad = new crmOportunidad();
            string mensaje = Blo.Properties.PropertiesBlo.msgExito;
            try
            {
                if (data.Id > 0)
                {
                    Oportunidad = _oportunidadBlo.GetById(data.Id);
                    if (!Oportunidad.URLActiva)
                    {
                        throw new Exception("Intento de duplicar información desde el formulario del buro, identificado con id:" + data.Id);
                    }
                }

                Oportunidad.BuroApellidos = data.BuroApellidos;
                Oportunidad.BuroCorreo = data.BuroCorreo;
                Oportunidad.BuroDUI = data.BuroDUI;
                Oportunidad.BuroGenero = data.BuroGenero;
                Oportunidad.BuroNIT = data.BuroNIT;
                Oportunidad.BuroNombres = data.BuroNombres;
                Oportunidad.BuroTelefono = data.BuroTelefono;
                Oportunidad.URLActiva = false;
                Oportunidad.URLFechaAcepto = DateTime.Now;
                Oportunidad.URLBuro = "";

                Oportunidad.Nombre = data.BuroNombres +" "+ data.BuroApellidos;

                if(!string.IsNullOrEmpty(data.BuroTelefono))
                    Oportunidad.Telefono = data.BuroTelefono;
                if (!string.IsNullOrEmpty(data.BuroCorreo))
                    Oportunidad.Correo = data.BuroCorreo;

                Oportunidad.Estado = "Precalificacion";


                _oportunidadBlo.Save(Oportunidad);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaginaNoEncontrada()
        {
            //string url = @"http://localhost:1089/Formulario";
            //QSencriptadoCSharp.QueryString parametros = new QSencriptadoCSharp.QueryString();
            //parametros.Add("a", "ñiñas #$%&()=(/&%$#ok");
            //url += QSencriptadoCSharp.Encryption.EncryptQueryString(parametros).ToString(); 

            return View();
        }
    }
}