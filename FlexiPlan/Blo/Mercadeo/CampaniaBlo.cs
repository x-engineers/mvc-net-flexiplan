using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Mercadeo;

namespace Blo.Mercadeo
{
    public class CampaniaBlo : GenericBlo<crmCampania>, ICampaniaBlo
    {
        private ICampaniaDao _campaniaDao;
        private ICampaniaSucursalDao _campaniaSucursalDao;
        private ICampaniaColorProductoDao _campaniaColorProductoDao;
        private ICampaniaProdPartesDao _campaniaProdPartesDao;
        private ICampaniaProdRegaliaDao _campaniaProdRegaliaDao;
        private ICampaniaProductoDao _campaniaProductoDao;

        public CampaniaBlo(ICampaniaDao campaniaDao, ICampaniaSucursalDao campaniaSucursalDao, ICampaniaColorProductoDao campaniaColorProductoDao,
            ICampaniaProdPartesDao campaniaProdPartesDao, ICampaniaProdRegaliaDao campaniaProdRegaliaDao, ICampaniaProductoDao campaniaProductoDao)
        : base(campaniaDao)
        {
            _campaniaDao = campaniaDao;
            _campaniaSucursalDao = campaniaSucursalDao;
            _campaniaColorProductoDao = campaniaColorProductoDao;
            _campaniaProdPartesDao = campaniaProdPartesDao;
            _campaniaProdRegaliaDao = campaniaProdRegaliaDao;
            _campaniaProductoDao = campaniaProductoDao;
        }


        /// <summary>
        /// Obtiene la todas las campañas activas
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de campañas</returns>
        public IQueryable<dynamic> GetCampaniaActivas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null)
        {

            try
            {
                return _campaniaDao.GetCampaniaActivas(idEmpresa, out total, page, limit, sortBy, direction, searchString);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Obtiene la todas las campañas en historial
        /// </summary>
        /// <returns>Lista de campañas</returns>
        public IQueryable<dynamic> GetCampaniaHistorial(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, Nullable<DateTime> fechaInicio = null, Nullable<DateTime> fechaFin = null)
        {
            try
            {
                return _campaniaDao.GetCampaniaHistorial(idEmpresa, out total, page, limit, sortBy, direction, searchString,fechaInicio,fechaFin);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Metodo para guardar toda la campaña con sus configuraciones y productos seleccionados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="campaniaProductos"></param>
        /// <param name="IdSucursales"></param>
        /// <param name="IdColores"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idUsuario"></param>
        public void SaveCampania(crmCampania data, List<crmCampaniaProducto> campaniaProductos, long[] IdSucursales, long[] IdColores, long idEmpresa, long idUsuario)
        {
            string mensaje = string.Empty;
            crmCampania Campania = new crmCampania();
            SQLBDEntities _SQLEntities = new SQLBDEntities();
            _SQLEntities.Configuration.ProxyCreationEnabled = false;
            
            using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
            {
                try
                {
                    if (data.Id != 0)
                    {
                        Campania = _campaniaDao.GetById(data.Id);
                        Campania.IdUsuarioModifico = idUsuario;
                        Campania.FechaModifico = DateTime.Now;
                    }
                    else
                    {
                        Campania.IdUsuarioAgrego = idUsuario;
                        Campania.FechaAgrego = DateTime.Now;
                    }
                   
                    Campania.IdEmpresa = idEmpresa;
                    Campania.IdTipoVenta = data.IdTipoVenta;
                    Campania.IdInvEstadoProducto = data.IdInvEstadoProducto;
                    Campania.IdInvClaseProducto = data.IdInvClaseProducto;
                    Campania.IdInvNivelPrecio = data.IdInvNivelPrecio;
                    Campania.Codigo = data.Codigo;
                    Campania.Nombre = data.Nombre;
                    Campania.Descripcion = data.Descripcion;
                    Campania.FechaInicio = data.FechaInicio;
                    Campania.FechaFinal = data.FechaFinal;
                    Campania.TipoDescuento = data.TipoDescuento;
                    Campania.Estado = crmCampania.ESTADO_ACTIVO;
                    Campania.IdInvMarca = data.IdInvMarca;

                    _campaniaDao.Save(Campania);

                    //eliminar datos de la campaña 
                    if (data.Id != 0)
                    {
                        //eliminar sucursales y colores
                        foreach (var c in _SQLEntities.crmCampaniaSucursal.AsNoTracking().Where(x => x.IdCampania == Campania.Id))
                            _campaniaSucursalDao.RemoveNoTrack(c.Id);
                        foreach (var c in _SQLEntities.crmCampaniaColorProducto.AsNoTracking().Where(x => x.IdCampania == Campania.Id))
                            _campaniaColorProductoDao.RemoveNoTrack(c.Id);


                        //Elimina dependencia de campaña
                        foreach (var p in _SQLEntities.crmCampaniaProducto.AsNoTracking().Where(x => x.IdCampania == Campania.Id))
                        {
                            foreach (var r in _SQLEntities.crmCampaniaProdRegalia.AsNoTracking().Where(x => x.IdCampaniaProducto == p.Id))
                                _campaniaProdRegaliaDao.RemoveNoTrack(r.Id);
                            foreach (var r in _SQLEntities.crmCampaniaProdPartes.AsNoTracking().Where(x => x.IdCampaniaProducto == p.Id))
                                _campaniaProdPartesDao.RemoveNoTrack(r.Id);

                            //eliminar producto
                            _campaniaProductoDao.RemoveNoTrack(p.Id);
                        }

                    }


                    //agregar sucursales
                    if (IdSucursales != null)
                        foreach (var item in IdSucursales)
                        {
                            crmCampaniaSucursal sucursales = new crmCampaniaSucursal();

                            sucursales.IdEmpresa = idEmpresa;
                            sucursales.IdCampania = Campania.Id;
                            sucursales.IdSucursalCampania = item;

                            _campaniaSucursalDao.Save(sucursales);
                        }

                    //agregar colores para chasis
                    if (IdColores != null)
                        foreach (var item in IdColores)
                        {
                            crmCampaniaColorProducto colores = new crmCampaniaColorProducto();

                            colores.IdEmpresa = idEmpresa;
                            colores.IdCampania = Campania.Id;
                            colores.IdInvColor = item;

                            _campaniaColorProductoDao.Save(colores);
                        }

                    //agregar nuevos productos
                    foreach (var item in campaniaProductos)
                    {
                        crmCampaniaProducto campaniaProducto = new crmCampaniaProducto();

                        //if (item.IdCampania > 0 && item.Id > 0)
                        //    campaniaProducto = _campaniaProductoDao.GetById(item.Id);

                        //crear producto
                        campaniaProducto.IdEmpresa = idEmpresa;
                        campaniaProducto.IdCampania = Campania.Id;
                        campaniaProducto.IdProducto = item.IdProducto;
                        campaniaProducto.TipoDescuento = Campania.TipoDescuento;
                        campaniaProducto.ValorDescuento = item.ValorDescuento;
                        campaniaProducto.ExistenciaActual = item.ExistenciaActual;
                        campaniaProducto.CantidadPromocion = item.CantidadPromocion;
                        campaniaProducto.PrecioActual = item.PrecioActual;
                        campaniaProducto.PrecioNuevo = item.PrecioNuevo;
                        campaniaProducto.TipoPrima = item.TipoPrima;
                        campaniaProducto.valorPrima = item.valorPrima;
                        campaniaProducto.Garantia = item.Garantia;
                        campaniaProducto.PrimerCuota = item.PrimerCuota;
                        _campaniaProductoDao.Save(campaniaProducto);

                        //agregar chasis
                        foreach (var Parte in item.crmCampaniaProdPartes)
                        {
                            crmCampaniaProdPartes campaniaProductoPartes = new crmCampaniaProdPartes();
                            campaniaProductoPartes.IdCampaniaProducto = campaniaProducto.Id;
                            campaniaProductoPartes.IdInvProductoPartes = Parte.IdInvProductoPartes;
                            campaniaProductoPartes.IdEmpresa = idEmpresa;
                            _campaniaProdPartesDao.SaveNoTrack(campaniaProductoPartes);
                        }

                        //agregar realias
                        foreach (var regalia in item.crmCampaniaProdRegalia)
                        {
                            crmCampaniaProdRegalia campaniaProdRegalia = new crmCampaniaProdRegalia();
                            campaniaProdRegalia.IdCampaniaProducto = campaniaProducto.Id;
                            campaniaProdRegalia.CantidadRegalia = regalia.CantidadRegalia;
                            campaniaProdRegalia.TipoCantidad = regalia.TipoCantidad;
                            campaniaProdRegalia.IdProducto = regalia.IdProducto;
                            campaniaProdRegalia.IdEmpresa = idEmpresa;
                            _campaniaProdRegaliaDao.SaveNoTrack(campaniaProdRegalia);
                        }
                    }

                    scope.Complete();
                }
                catch (Exception e)
                {
                    log.Error(e);
                    mensaje = "Campaña no fue guardada, revisar log.error";
                }
            }

            //Notificar de posibles errores
            if (!string.IsNullOrEmpty(mensaje))
                throw new Exception(mensaje);
        }

        /// <summary>
        /// Metodo para obtener las campanias que esa queesten en estado  activas filtradas por el Id de la empresa
        /// </summary>
        /// <param name="idEmpresa">empresa a la pertenece el usuario</param>
        /// <returns>Lista de campanias en estado activas</returns>
        public List<crmCampania> GetListaActuales(long idEmpresa)
        {
            return _campaniaDao.GetListaActuales(idEmpresa);
        }

    }
}
