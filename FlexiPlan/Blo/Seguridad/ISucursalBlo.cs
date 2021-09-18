using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Seguridad
{
    public interface ISucursalBlo : IGenericBlo<Sucursal>
    {
        /// <summary>
        /// Metodo que permite obtener todas las agencias por empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de sucursales</returns>
        List<Sucursal> GetSucursalxEmpresa(long idEmpresa);
    }
}
