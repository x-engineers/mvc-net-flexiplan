using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Seguridad
{
    public class PeriodoDao : GenericDao<Periodo>, IPeriodoDao
    {
        /// <summary>
        /// Metodo que permite obtener todos los periodos activos de una empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de periodos</returns>
        public List<Periodo> GetPeriodoActivosxEmpresa(long idEmpresa)
        {
            List<Periodo> lista = new List<Periodo>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                lista = _SQLBDEntities.Periodo.Include("Meses").Include("Ejercicio")
                        .Where(x => x.IdEmpresa == idEmpresa && !x.Cerrado && x.Activo)
                        .ToList();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
