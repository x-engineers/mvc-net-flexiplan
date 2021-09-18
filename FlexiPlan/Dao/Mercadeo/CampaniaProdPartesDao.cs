using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public class CampaniaProdPartesDao : GenericDao<crmCampaniaProdPartes>, ICampaniaProdPartesDao
    {
        /// <summary>
        /// Metodo que permite obtener todas las partes del producto(chasis)
        /// </summary>
        /// <param name="idProducto">Código de producto</param>
        /// <param name="idColores">Código de colores</param>
        /// <returns>Lista de chasis o partes de un producto</returns>
        public List<InvProductoPartes> GetProductoPartes(long idProducto, long[] idColores)
        {
            List<InvProductoPartes> lista = new List<InvProductoPartes>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                lista = _SQLBDEntities.InvProductoPartes.AsNoTracking()
                        .Where(x => x.IdInvProducto==idProducto && (idColores.Where(c=> c!=0).Any()? idColores.Contains(x.IdInvColor): x.IdInvColor==x.IdInvColor) && x.Existencia>0)
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
