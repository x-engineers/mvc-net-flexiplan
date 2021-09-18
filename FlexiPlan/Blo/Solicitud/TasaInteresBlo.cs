using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Solicitud;

namespace Blo.Solicitud
{
    public class TasaInteresBlo : GenericBlo<crmTasaInteres>, ITasaInteresBlo
    {
        private ITasaInteresDao _tasaInteresDao;

        public TasaInteresBlo(ITasaInteresDao tasaInteresDao)
        : base(tasaInteresDao)
        {
            _tasaInteresDao = tasaInteresDao;
        }

        /// <summary>
        /// Permite obtener la tasa de interes por default para el crédito
        /// </summary>
        /// <returns>objeto de tasa de interes</returns>
        public crmTasaInteres GetDefault()
        {
            crmTasaInteres tasaInteres = new crmTasaInteres();
            try
            {
                tasaInteres = _tasaInteresDao.GetDefault();
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
            try
            {
                tasaInteres = _tasaInteresDao.GetTasaInteres();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return tasaInteres;
        }
    }
}
