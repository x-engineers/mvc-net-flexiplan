using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public class OportunidadDao : GenericDao<crmOportunidad>, IOportunidadDao
    {
        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        public IQueryable<dynamic> GetOportunidades(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null,string estado = null,long idEmpleado = 0)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = true;
            List<crmOportunidad> listaOportunidad = new List<crmOportunidad>();
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
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado==null?crmOportunidad.ESTADO_PENDIENTE:estado) && x.IdEmpleado == (idEmpleado>0?idEmpleado:x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.Correo + " " +
                              x.ComentarioCalificacion + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.ComentarioCalificacion + " " +
                              x.Correo + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                       .Count();
                }
                else
                {
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                       .Count();
                }

                lista = listaOportunidad
                    .Select(x => new
                    {
                        x.Id,
                        x.FechaModifico,
                        x.IdUsuarioModifico,
                        x.FechaAgrego,
                        x.IdUsuarioAgrego,
                        x.IdEmpresa,
                        x.Nombre,
                        x.Telefono,
                        x.Correo,
                        x.OrigenConctacto,
                        x.DescripcionOrigen,
                        x.IdCampania,
                        x.IdTipoVenta,
                        interes = x.crmTipoVenta.Descripcion,
                        x.Observacion,
                        x.Estado,
                        x.URLBuro,
                        x.URLActiva,
                        x.URLFechaAcepto,
                        x.URLFechaEnvio,
                        x.IdTipoMedio,
                        x.IdMedioContacto,
                        MedioContacto = _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault()==null?"":
                        _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault().MedioContacto,
                        x.BuroNombres,
                        x.BuroApellidos,
                        x.BuroGenero,
                        x.BuroDUI,
                        x.BuroNIT,
                        x.BuroCorreo,
                        x.BuroTelefono,
                        x.Calificacion,
                        x.ComentarioCalificacion,
                        x.IdAnalista,
                        x.FechaAnalisis,
                        x.ComentarioAnalisis,
                        x.FechaComite,
                        x.FechaVenta
                    }).AsQueryable();

            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }


        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        public IQueryable<dynamic> GetSolAsignadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, string estado = null, long idEmpleado = 0)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = true;
            List<crmOportunidad> listaOportunidad = new List<crmOportunidad>();
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
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdAnalista == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.Correo + " " +
                              x.ComentarioCalificacion + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdAnalista == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.ComentarioCalificacion + " " +
                              x.Correo + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                       .Count();
                }
                else
                {
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdAnalista == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.Estado == (estado == null ? crmOportunidad.ESTADO_PENDIENTE : estado) && x.IdAnalista == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                       .Count();
                }

                lista = listaOportunidad
                    .Select(x => new
                    {
                        x.Id,
                        x.FechaModifico,
                        x.IdUsuarioModifico,
                        x.FechaAgrego,
                        x.IdUsuarioAgrego,
                        x.IdEmpresa,
                        x.Nombre,
                        x.Telefono,
                        x.Correo,
                        x.OrigenConctacto,
                        x.DescripcionOrigen,
                        x.IdCampania,
                        x.IdTipoVenta,
                        interes = x.crmTipoVenta.Descripcion,
                        x.Observacion,
                        x.Estado,
                        x.URLBuro,
                        x.URLActiva,
                        x.URLFechaAcepto,
                        x.URLFechaEnvio,
                        x.IdTipoMedio,
                        x.IdMedioContacto,
                        MedioContacto = _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault() == null ? "" :
                        _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault().MedioContacto,
                        x.BuroNombres,
                        x.BuroApellidos,
                        x.BuroGenero,
                        x.BuroDUI,
                        x.BuroNIT,
                        x.BuroCorreo,
                        x.BuroTelefono,
                        x.Calificacion,
                        x.ComentarioCalificacion,
                        x.IdAnalista,
                        x.FechaAnalisis,
                        x.ComentarioAnalisis,
                        x.FechaComite,
                        x.FechaVenta
                    }).AsQueryable();

            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }

        /// <summary>
        /// Obtiene el numero de oportunidades asignadas por empleado
        /// </summary>
        /// <param name="idEmpleado">Código de empleado</param>
        /// <returns>Total de oportunidades asignadas</returns>
        public long TotalAsingadas(long idEmpleado)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            long total = 0;
            try
            {
                total = _SQLBDEntities.crmOportunidad.AsNoTracking().Where(x => x.IdEmpleado == idEmpleado && x.Estado == crmOportunidad.ESTADO_ASIGNADO).Count();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return total;
        }


        /// <summary>
        /// Obtiene la todas las oportunidades en un estado aprobadas u condicionadas
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        public IQueryable<dynamic> GetOportunidadesAprobadasCondicionadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null,  long idEmpleado = 0)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = true;
            List<crmOportunidad> listaOportunidad = new List<crmOportunidad>();
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
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && (x.Estado == crmOportunidad.ESTADO_CREDITO_CONDICIONADO || x.Estado == crmOportunidad.ESTADO_CREDITO_APROBADO)   && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.Correo + " " +
                              x.ComentarioCalificacion + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && (x.Estado == crmOportunidad.ESTADO_CREDITO_CONDICIONADO || x.Estado == crmOportunidad.ESTADO_CREDITO_APROBADO) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado) &&
                             (x.Nombre + " " +
                              x.Telefono + " " +
                              x.OrigenConctacto + " " +
                              x.crmTipoVenta.Descripcion + " " +
                              x.ComentarioCalificacion + " " +
                              x.Correo + " " +
                              x.Observacion
                             ).ToUpper().Contains(searchString.Trim().ToUpper()))
                       .Count();
                }
                else
                {
                    listaOportunidad = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && (x.Estado == crmOportunidad.ESTADO_CREDITO_CONDICIONADO || x.Estado == crmOportunidad.ESTADO_CREDITO_APROBADO) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                        .OrderBy(x => x.Id)
                        .Skip(start)
                        .Take(limit.Value)
                        .ToList();

                    total = _SQLBDEntities.crmOportunidad.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && (x.Estado == crmOportunidad.ESTADO_CREDITO_CONDICIONADO || x.Estado == crmOportunidad.ESTADO_CREDITO_APROBADO) && x.IdEmpleado == (idEmpleado > 0 ? idEmpleado : x.IdEmpleado))
                       .Count();
                }

                lista = listaOportunidad
                    .Select(x => new
                    {
                        x.Id,
                        x.FechaModifico,
                        x.IdUsuarioModifico,
                        x.FechaAgrego,
                        x.IdUsuarioAgrego,
                        x.IdEmpresa,
                        x.Nombre,
                        x.Telefono,
                        x.Correo,
                        x.OrigenConctacto,
                        x.DescripcionOrigen,
                        x.IdCampania,
                        x.IdTipoVenta,
                        interes = x.crmTipoVenta.Descripcion,
                        x.Observacion,
                        x.Estado,
                        x.URLBuro,
                        x.URLActiva,
                        x.URLFechaAcepto,
                        x.URLFechaEnvio,
                        x.IdTipoMedio,
                        x.IdMedioContacto,
                        MedioContacto = _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault() == null ? "" :
                        _SQLBDEntities.crmMedioContacto.AsNoTracking().Where(m => m.Id == x.IdMedioContacto).FirstOrDefault().MedioContacto,
                        x.BuroNombres,
                        x.BuroApellidos,
                        x.BuroGenero,
                        x.BuroDUI,
                        x.BuroNIT,
                        x.BuroCorreo,
                        x.BuroTelefono,
                        x.Calificacion,
                        x.ComentarioCalificacion,
                        x.IdAnalista,
                        x.FechaAnalisis,
                        x.ComentarioAnalisis,
                        x.FechaComite,
                        x.FechaVenta
                    }).AsQueryable();

            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }

    }
}
