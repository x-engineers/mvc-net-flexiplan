using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public interface ICampaniaDao : IGenericDao<crmCampania>
    {
        /// <summary>
        /// Obtiene la todas las campañas activas
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de campañas</returns>
        IQueryable<dynamic> GetCampaniaActivas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null);
        /// <summary>
        /// Obtiene la todas las campañas en historial
        /// </summary>
        /// <returns>Lista de campañas</returns>
        IQueryable<dynamic> GetCampaniaHistorial(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, Nullable<DateTime> fechaInicio = null, Nullable<DateTime> fechaFin = null);

        /// <summary>
        /// Metodo para obtener las campanias que esa queesten en estado  activas filtradas por el Id de la empresa
        /// </summary>
        /// <param name="idEmpresa">empresa a la pertenece el usuario</param>
        /// <returns>Lista de campanias en estado activas</returns>
        List<crmCampania> GetListaActuales(long idEmpresa);
    }
}
