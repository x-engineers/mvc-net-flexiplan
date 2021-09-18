using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Mercadeo
{
    public interface ICampaniaProdPartesBlo : IGenericBlo<crmCampaniaProdPartes>
    {
        /// <summary>
        /// Metodo que permite obtener todas las partes del producto(chasis)
        /// </summary>
        /// <param name="idProducto">Código de producto</param>
        /// <param name="idColores">Código de colores</param>
        /// <returns>Lista de chasis o partes de un producto</returns>
        List<InvProductoPartes> GetProductoPartes(long idProducto, long[] idColores);
    }
}
