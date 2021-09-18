using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Mercadeo;
using Dao.Solicitud;

namespace Blo.Mercadeo
{
    public class OportunidadBlo : GenericBlo<crmOportunidad>, IOportunidadBlo
    {
        private IOportunidadDao _oportunidadDao;
        private IContactoDao _contactoDao;

        public OportunidadBlo(IOportunidadDao oportunidadDao, IContactoDao contactoDao)
        : base(oportunidadDao)
        {
            _oportunidadDao = oportunidadDao;
            _contactoDao = contactoDao;
        }

        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        public IQueryable<dynamic> GetOportunidades(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, string estado = null, long idEmpleado = 0)
        {
            try
            {

                return _oportunidadDao.GetOportunidades(idEmpresa, out total, page, limit, sortBy, direction, searchString, estado, idEmpleado);

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Obtiene el numero de oportunidades asignadas por empleado
        /// </summary>
        /// <param name="idEmpleado">Código de empleado</param>
        /// <returns>Total de oportunidades asignadas</returns>
        public long TotalAsingadas(long idEmpleado)
        {
            long total = 0;
            try
            {
                total = _oportunidadDao.TotalAsingadas(idEmpleado);
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
        public IQueryable<dynamic> GetOportunidadesAprobadasCondicionadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, long idEmpleado = 0)
        {
            try
            {

                return _oportunidadDao.GetOportunidadesAprobadasCondicionadas(idEmpresa, out total, page, limit, sortBy, direction, searchString, idEmpleado);

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        public IQueryable<dynamic> GetSolAsignadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, string estado = null, long idEmpleado = 0)
        {
            try
            {

                return _oportunidadDao.GetSolAsignadas(idEmpresa, out total, page, limit, sortBy, direction, searchString,estado, idEmpleado);

            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception(e.Message);
            }

        }


    }
}
