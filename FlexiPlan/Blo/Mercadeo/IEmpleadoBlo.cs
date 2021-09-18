using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Mercadeo
{
    public interface IEmpleadoBlo : IGenericBlo<rrhEmpleado>
    {
        /// <summary>
        /// Metodo que de vuelve la lista de vendedores
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        List<rrhEmpleado> GetVendedores(long idEmpresa);
    }
}
