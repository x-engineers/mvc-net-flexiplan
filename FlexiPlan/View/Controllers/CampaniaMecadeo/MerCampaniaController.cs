using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blo.Mercadeo;
using Blo.Seguridad;
using Blo.Properties;
using Model;
using Ninject;
using Blo;
using System.Reflection;

namespace View.Controllers.Mercadeo
{
    [NoCache]
    [Autorizacion]
    public class MerCampaniaController : BaseController
    {

        /// <summary>
        /// instancia de la interfas para poder hacer el CRUD
        /// </summary>
        /// <returns></returns>
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


        public ActionResult Index()
        {
            ViewBag.sucursales = _sucursalesBlo.GetSucursalxEmpresa(GetEmpresa());
            ViewBag.color = _colorBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.estadoProducto = _estadoProductoBlo.GetAll();
            ViewBag.nivelPrecio = _nivelPrecioBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.clase = _claseBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.tipoVenta = _tipoVentaBlo.GetAll();
            ViewBag.marca = _marcaBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.servicios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_SERVICIO);
            ViewBag.accesorios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_ACCESORIO);

            Session["CampaniaProductos"] = new List<crmCampaniaProducto>();

            return View();
        }

        public ActionResult MerCampaniaHis()
        {
            ViewBag.sucursales = _sucursalesBlo.GetSucursalxEmpresa(GetEmpresa());
            ViewBag.color = _colorBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.estadoProducto = _estadoProductoBlo.GetAll();
            ViewBag.nivelPrecio = _nivelPrecioBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.clase = _claseBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.tipoVenta = _tipoVentaBlo.GetAll();
            ViewBag.marca = _marcaBlo.GetDatosDetalle("IdEmpresa", GetEmpresa());
            ViewBag.servicios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_SERVICIO);
            ViewBag.accesorios = _productosBlo.GetProductosServicioAccesorio(GetEmpresa(), InvProducto.CLASE_PRODUCTO_ACCESORIO);

            Session["CampaniaProductos"] = new List<crmCampaniaProducto>();

            return View();
        }


        [HttpGet]
        public JsonResult GetCampaniaActivas(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            try
            {
                int total = 0;
                var records = _campaniaBlo.GetCampaniaActivas(GetEmpresa(), out total, page, limit, sortBy, direction, searchString);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }

        [HttpGet]
        public JsonResult GetCampaniaHistorial(int? page, int? limit, string sortBy, string direction, string searchString = null, string buscarFechaIni = null, string buscarFechaFin = null)
        {

            try
            {
                int total = 0;
                Nullable<DateTime> fi = null;
                Nullable<DateTime> ff = null;
                if (buscarFechaIni != null && buscarFechaIni != "" && buscarFechaFin != null && buscarFechaFin != "")
                {
                    fi = DateTime.Parse(buscarFechaIni);
                    ff = DateTime.Parse(buscarFechaFin);
                }

                var records = _campaniaBlo.GetCampaniaHistorial(GetEmpresa(), out total, page, limit, sortBy, direction, searchString, fi, ff);

                return Json(new { records, total }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw new System.ArgumentException("Error obteniendo lista los datos");
            }
        }


        [HttpPost]
        public JsonResult Save(crmCampania data, long[] IdSucursales, long[] IdColores)
        {

            string mensaje = PropertiesBlo.msgExito;

            try
            {
                _campaniaBlo.ValidarSave(data.Id, GetRol(), GetOpcion(), GetEmpresa());

                _campaniaBlo.SaveCampania(data, (List<crmCampaniaProducto>)Session["CampaniaProductos"], IdSucursales, IdColores, GetEmpresa(), GetIdUsuario());
                Session["CampaniaProductos"] = new List<crmCampaniaProducto>();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }


            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Limpiar()
        {
            Session["CampaniaProductos"] = new List<crmCampaniaProducto>();
        }

        [HttpPost]
        public JsonResult CancelarCampania(int id)
        {
            crmCampania Campania = new crmCampania();
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                _campaniaBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.EDITAR, GetEmpresa());

                if (id != 0)
                {
                    Campania = _campaniaBlo.GetById(id);
                    Campania.Estado = crmCampania.ESTADO_CANCELADO;
                    Campania.FechaFinal = DateTime.Now;
                    _campaniaBlo.Save(Campania);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }
            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }



        #region Agregar Productos

        [HttpGet]
        public JsonResult GetProductos(bool detalle = false)
        {
            try
            {
                var records = ((List<crmCampaniaProducto>)Session["CampaniaProductos"])
                    .Select(x => new
                    {
                        x.Id,
                        x.IdProducto,
                        CodigoProducto = _productosBlo.GetById(x.IdProducto).Codigo,
                        Producto = _productosBlo.GetById(x.IdProducto).InvProductoDes,
                        x.TipoDescuento,
                        x.ValorDescuento,
                        x.CantidadPromocion,
                        x.PrecioNuevo,
                        x.ExistenciaActual,
                        x.Garantia,
                        x.IdCampania,
                        x.IdEmpresa,
                        x.PrecioActual,
                        x.TipoPrima,
                        x.valorPrima,
                        x.PrimerCuota,
                        servicios = x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").Any() ?
                        x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").FirstOrDefault().IdProducto : 0,
                        Kilometraje = x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").Any() ?
                        x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Kilometraje").FirstOrDefault().CantidadRegalia : 0,
                        accesorios = x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").Any() ?
                        x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").FirstOrDefault().IdProducto : 0,
                        Cantidad = x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").Any() ?
                        x.crmCampaniaProdRegalia.Where(s => s.TipoCantidad == "Cantidad").FirstOrDefault().CantidadRegalia : 0,
                        idPartes = x.crmCampaniaProdPartes.Select(p => p.IdInvProductoPartes),
                        Edit = detalle ? "S" : "",
                        Delete = detalle ? "S" : ""
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
        public JsonResult AgregarProducto(crmCampaniaProducto product, long servicios = 0, int Kilometraje = 0, long accesorios = 0, int Cantidad = 0, long[] idPartes = null)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                long ultimo = 1;

                if (((List<crmCampaniaProducto>)Session["CampaniaProductos"]).Any())
                    ultimo = ((List<crmCampaniaProducto>)Session["CampaniaProductos"]).OrderByDescending(c => c.Id).First().Id + 1;

                if (product.Id != 0)
                {
                    Session["CampaniaProductos"] = ((List<crmCampaniaProducto>)Session["CampaniaProductos"])
                        .Where(x => x.Id != product.Id)
                        .ToList();
                }

                product.Id = ultimo;

                if (servicios != 0)
                {
                    crmCampaniaProdRegalia regServicio = new crmCampaniaProdRegalia();
                    regServicio.IdCampaniaProducto = ultimo;
                    regServicio.CantidadRegalia = Kilometraje;
                    regServicio.IdProducto = servicios;
                    regServicio.TipoCantidad = "Kilometraje";
                    product.crmCampaniaProdRegalia.Add(regServicio);
                }

                if (accesorios != 0)
                {
                    crmCampaniaProdRegalia regServicio2 = new crmCampaniaProdRegalia();
                    regServicio2.IdCampaniaProducto = ultimo;
                    regServicio2.CantidadRegalia = Cantidad;
                    regServicio2.IdProducto = accesorios;
                    regServicio2.TipoCantidad = "Cantidad";
                    product.crmCampaniaProdRegalia.Add(regServicio2);
                }


                if (idPartes != null)
                    foreach (var item in idPartes)
                    {
                        crmCampaniaProdPartes prodPartes = new crmCampaniaProdPartes();
                        prodPartes.IdCampaniaProducto = ultimo;
                        prodPartes.IdInvProductoPartes = item;
                        product.crmCampaniaProdPartes.Add(prodPartes);
                    }

                ((List<crmCampaniaProducto>)Session["CampaniaProductos"]).Add(product);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                mensaje = ex.Message;
            }

            return Json(new { mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveProducto(int id = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            crmCampaniaProducto producto = new crmCampaniaProducto();
            try
            {
                _campaniaBlo.ValidarPermiso(GetRol(), GetOpcion(), crmParametro.ELIMINAR, GetEmpresa());

                Session["CampaniaProductos"] = ((List<crmCampaniaProducto>)Session["CampaniaProductos"])
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

        [HttpPost]
        public JsonResult GetProductosCampania(long IdCampania = 0)
        {
            string mensaje = PropertiesBlo.msgExito;
            try
            {
                Session["CampaniaProductos"] = _campaniaProductoBlo.GetDatosDetalle("IdCampania", IdCampania, true);
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
        public JsonResult GetProductosClaseMarca(long idClase, long idEstadoProducto, long idNivelPrecio, long idMarca = 0)
        {
            IQueryable<dynamic> lista = _productosBlo.GetProductosClaseMarca(GetEmpresa(), idClase, idMarca, idEstadoProducto, idNivelPrecio);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDatosProducto(long idProducto, long idNivelPrecio, long[] idColores)
        {
            InvProducto datos = _productosBlo.GetDatosProducto(GetEmpresa(), idProducto, idNivelPrecio);
            List<InvProductoPartes> partes = _campaniaProdPartesBlo.GetProductoPartes(idProducto, idColores);

            return Json(new { datos, partes }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDatosProdPartes(long idProducto, long[] idColores)
        {
            List<InvProductoPartes> partes = _campaniaProdPartesBlo.GetProductoPartes(idProducto, idColores);

            return Json(new { partes }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
