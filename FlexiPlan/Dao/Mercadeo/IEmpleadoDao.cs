using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public interface IEmpleadoDao : IGenericDao<rrhEmpleado>
    {
        /// <summary>
        /// Metodo que de vuelve la lista de vendedores
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        List<rrhEmpleado> GetVendedores(long idEmpresa);

    }
}
