using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public class EmpleadoDao : GenericDao<rrhEmpleado>, IEmpleadoDao
    {
        /// <summary>
        /// Metodo que de vuelve la lista de vendedores
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<rrhEmpleado> GetVendedores(long idEmpresa)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();

            List<rrhEmpleado> lista = new List<rrhEmpleado>();
            try
            {
                lista = _SQLBDEntities.rrhEmpleado.AsNoTracking()
                        .Where(x => x.EsVendedor==true && x.IdEmpresa== idEmpresa)
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
