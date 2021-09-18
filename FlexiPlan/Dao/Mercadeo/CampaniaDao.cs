using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public class CampaniaDao : GenericDao<crmCampania>, ICampaniaDao
    {
        /// <summary>
        /// Obtiene la todas las campañas activas
        /// </summary>
        /// <returns>Lista de campañas</returns>
        public IQueryable<dynamic> GetCampaniaActivas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = true;
            IQueryable<dynamic> lista = null;
            int start = (page.Value - 1) * limit.Value;
            sortBy = sortBy == null ? "Id" : sortBy;
            direction = direction == null ? "asc" : direction;
            total = 0;

            try
            {

                //Buscar
                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    lista = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta").Include("crmCampaniaSucursal").Include("crmCampaniaColorProducto")
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == crmCampania.ESTADO_ACTIVO &&
                             (x.Codigo + " " +
                              x.Nombre + " " +
                              x.Descripcion + " " +
                              x.crmTipoVenta.Descripcion 
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList()
                        .Select(x => new
                        {
                            x.Id,
                            x.IdEmpresa,
                            x.IdInvClaseProducto,
                            x.IdInvEstadoProducto,
                            x.IdInvNivelPrecio,
                            x.IdTipoVenta,
                            x.IdUsuarioAgrego,
                            x.IdUsuarioModifico,
                            x.TipoDescuento,
                            x.FechaModifico,
                            x.FechaAgrego,
                            x.Estado,
                            x.Codigo,
                            x.Nombre,
                            x.Descripcion,
                            x.FechaInicio,
                            x.FechaFinal,
                            x.IdInvMarca,
                            TipoVenta = x.crmTipoVenta.Descripcion,
                            IdSucursales =  x.crmCampaniaSucursal.Select(sp => sp.IdSucursalCampania),
                            IdColores =  x.crmCampaniaColorProducto.Select(cp => cp.IdInvColor)
                        })
                         .AsQueryable();

                    total = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta")
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == crmCampania.ESTADO_ACTIVO &&
                             (x.Codigo + " " +
                              x.Nombre + " " +
                              x.Descripcion + " " +
                              x.crmTipoVenta.Descripcion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                       .Count();
                }
                else
                {
                    lista = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta").Include("crmCampaniaSucursal").Include("crmCampaniaColorProducto")
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == crmCampania.ESTADO_ACTIVO)
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList()
                        .Select(x => new
                        {
                            x.Id,
                            x.IdEmpresa,
                            x.IdInvClaseProducto,
                            x.IdInvEstadoProducto,
                            x.IdInvNivelPrecio,
                            x.IdTipoVenta,
                            x.IdUsuarioAgrego,
                            x.IdUsuarioModifico,
                            x.TipoDescuento,
                            x.FechaModifico,
                            x.FechaAgrego,
                            x.Estado,
                            x.Codigo,
                            x.Nombre,
                            x.Descripcion,
                            x.FechaInicio,
                            x.FechaFinal,
                            x.IdInvMarca,
                            TipoVenta = x.crmTipoVenta.Descripcion,
                            IdSucursales =  x.crmCampaniaSucursal.Select(sp => sp.IdSucursalCampania),
                            IdColores =  x.crmCampaniaColorProducto.Select(cp => cp.IdInvColor)
                        })
                         .AsQueryable();

                    total = _SQLBDEntities.crmCampania
                       .Where(x => x.IdEmpresa == idEmpresa && x.Estado == crmCampania.ESTADO_ACTIVO)
                       .Count();
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la todas las campañas en historial
        /// </summary>
        /// <returns>Lista de campañas</returns>
        public IQueryable<dynamic> GetCampaniaHistorial(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, Nullable<DateTime> fechaInicio = null, Nullable<DateTime> fechaFin = null)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = true;
            IQueryable<dynamic> lista = null;
            int start = (page.Value - 1) * limit.Value;
            sortBy = sortBy == null ? "Id" : sortBy;
            direction = direction == null ? "asc" : direction;
            total = 0;
            bool filtroFechas = (fechaInicio != null && fechaFin != null);
            //Agregando 23 horas para evitar problemas al seleccionar la misma fecha
            fechaFin = (fechaFin == null ? fechaFin : fechaFin.Value.AddHours(23));

            try
            {

                //Buscar
                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    lista = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta").Include("crmCampaniaSucursal").Include("crmCampaniaColorProducto")
                        .Where(x => x.IdEmpresa == idEmpresa &&
                         x.FechaFinal >= (filtroFechas ? fechaInicio.Value : x.FechaInicio) &&
                         x.FechaFinal <= (filtroFechas ? fechaFin.Value : x.FechaFinal) &&
                        (x.Estado == crmCampania.ESTADO_CANCELADO || x.Estado==crmCampania.ESTADO_INACTIVO) &&
                             (x.Codigo + " " +
                              x.Nombre + " " +
                              x.Descripcion + " " +
                              x.crmTipoVenta.Descripcion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList()
                        .Select(x => new
                        {
                            x.Id,
                            x.IdEmpresa,
                            x.IdInvClaseProducto,
                            x.IdInvEstadoProducto,
                            x.IdInvNivelPrecio,
                            x.IdTipoVenta,
                            x.IdUsuarioAgrego,
                            x.IdUsuarioModifico,
                            x.TipoDescuento,
                            x.FechaModifico,
                            x.FechaAgrego,
                            x.Estado,
                            x.Codigo,
                            x.Nombre,
                            x.Descripcion,
                            x.FechaInicio,
                            x.FechaFinal,
                            x.IdInvMarca,
                            TipoVenta = x.crmTipoVenta.Descripcion,
                            IdSucursales = x.crmCampaniaSucursal.Select(sp => sp.IdSucursalCampania),
                            IdColores = x.crmCampaniaColorProducto.Select(cp => cp.IdInvColor)
                        })
                         .AsQueryable();

                    total = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta")
                        .Where(x => x.IdEmpresa == idEmpresa &&
                         x.FechaFinal >= (filtroFechas ? fechaInicio.Value : x.FechaInicio) &&
                         x.FechaFinal <= (filtroFechas ? fechaFin.Value : x.FechaFinal) &&
                        (x.Estado == crmCampania.ESTADO_CANCELADO || x.Estado == crmCampania.ESTADO_INACTIVO) &&
                             (x.Codigo + " " +
                              x.Nombre + " " +
                              x.Descripcion + " " +
                              x.crmTipoVenta.Descripcion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                       .Count();
                }
                else
                {
                    lista = _SQLBDEntities.crmCampania.AsNoTracking().Include("crmTipoVenta").Include("crmCampaniaSucursal").Include("crmCampaniaColorProducto")
                        .Where(x => x.IdEmpresa == idEmpresa &&  (x.Estado == crmCampania.ESTADO_CANCELADO || x.Estado == crmCampania.ESTADO_INACTIVO))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList()
                        .Select(x => new
                        {
                            x.Id,
                            x.IdEmpresa,
                            x.IdInvClaseProducto,
                            x.IdInvEstadoProducto,
                            x.IdInvNivelPrecio,
                            x.IdTipoVenta,
                            x.IdUsuarioAgrego,
                            x.IdUsuarioModifico,
                            x.TipoDescuento,
                            x.FechaModifico,
                            x.FechaAgrego,
                            x.Estado,
                            x.Codigo,
                            x.Nombre,
                            x.Descripcion,
                            x.FechaInicio,
                            x.FechaFinal,
                            x.IdInvMarca,
                            TipoVenta = x.crmTipoVenta.Descripcion,
                            IdSucursales = x.crmCampaniaSucursal.Select(sp => sp.IdSucursalCampania),
                            IdColores = x.crmCampaniaColorProducto.Select(cp => cp.IdInvColor)
                        })
                         .AsQueryable();

                    total = _SQLBDEntities.crmCampania
                       .Where(x => x.IdEmpresa == idEmpresa && (x.Estado == crmCampania.ESTADO_CANCELADO || x.Estado == crmCampania.ESTADO_INACTIVO))
                       .Count();
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }


        /// <summary>
        /// Metodo para obtener las campanias que esa queesten en estado  activas filtradas por el Id de la empresa
        /// </summary>
        /// <param name="idEmpresa">empresa a la pertenece el usuario</param>
        /// <returns>Lista de campanias en estado activas</returns>
        public List<crmCampania> GetListaActuales(long idEmpresa)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();

            List<crmCampania> lista = new List<crmCampania>();
            try
            {
                 lista = _SQLBDEntities.crmCampania.AsNoTracking()
                         .Where(x => x.IdEmpresa == idEmpresa && x.Estado == crmCampania.ESTADO_ACTIVO)
                         .ToList();
            }
            catch (Exception ex)
            {

                log.Error(ex);
            }

            return lista;
        }
    }
}
