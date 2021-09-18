using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Solicitud
{
    public class TasaInteresDao : GenericDao<crmTasaInteres>, ITasaInteresDao
    {
        /// <summary>
        /// Permite obtener la tasa de interes por default para el crédito
        /// </summary>
        /// <returns>objeto de tasa de interes</returns>
        public crmTasaInteres GetDefault()
        {
            crmTasaInteres tasaInteres = new crmTasaInteres();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                var tasa = _SQLBDEntities.crmTasaInteres.AsNoTracking().Where(x => !x.Inactivo && x.Default);
                if (tasa.Any())
                    tasaInteres = tasa.FirstOrDefault();  
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return tasaInteres;
        }

        /// <summary>
        /// Permite obtener una lista de tasas de intereses activas
        /// </summary>
        /// <returns>Lista de tasas de interes</returns>
        public List<crmTasaInteres> GetTasaInteres()
        {
            List<crmTasaInteres> tasaInteres = new List<crmTasaInteres>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                 tasaInteres = _SQLBDEntities.crmTasaInteres.AsNoTracking().Where(x => !x.Inactivo).ToList();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return tasaInteres;
        }
    }
}
