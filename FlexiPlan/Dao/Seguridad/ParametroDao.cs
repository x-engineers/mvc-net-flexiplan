using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Seguridad
{
    public class ParametroDao : GenericDao<crmParametro>, IParametroDao
    {
        /// <summary>
        /// Obtiene un objeto de tipo SEG_PARAMETRO
        /// </summary>
        /// <param name="codigo">codigo para identificar el parametro</param>
        /// <returns>objeto</returns>
        public crmParametro GetParametroByCodigo(string codigo)
        {
            crmParametro lista = new crmParametro();
            try
            {
                lista = _SQLBDEntities.crmParametro
                        .Where(x => x.Codigo == codigo)
                        .First();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
