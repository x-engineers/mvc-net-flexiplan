using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Seguridad;

namespace Blo.Seguridad
{
   public class PeriodoBlo : GenericBlo<Periodo>, IPeriodoBlo
   {
       private IPeriodoDao _periodoDao;
       
          public PeriodoBlo(IPeriodoDao periodoDao)
          : base(periodoDao)
          {
              _periodoDao =periodoDao;
          }

        /// <summary>
        /// Metodo que permite obtener todos los periodos activos de una empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de periodos</returns>
        public List<Periodo> GetPeriodoActivosxEmpresa(long idEmpresa)
        {
            List<Periodo> lista = new List<Periodo>();
            try
            {
                lista = _periodoDao.GetPeriodoActivosxEmpresa(idEmpresa);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
