using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Mercadeo;

namespace Blo.Mercadeo
{
    public class CampaniaProdPartesBlo : GenericBlo<crmCampaniaProdPartes>, ICampaniaProdPartesBlo
    {
        private ICampaniaProdPartesDao _campaniaProdPartesDao;

        public CampaniaProdPartesBlo(ICampaniaProdPartesDao campaniaProdPartesDao)
        : base(campaniaProdPartesDao)
        {
            _campaniaProdPartesDao = campaniaProdPartesDao;
        }

        /// <summary>
        /// Metodo que permite obtener todas las partes del producto(chasis)
        /// </summary>
        /// <param name="idProducto">Código de producto</param>
        /// <param name="idColores">Código de colores</param>
        /// <returns>Lista de chasis o partes de un producto</returns>
        public List<InvProductoPartes> GetProductoPartes(long idProducto, long[] idColores)
        {
            List<InvProductoPartes> lista = new List<InvProductoPartes>();
            try
            {
                lista = _campaniaProdPartesDao.GetProductoPartes(idProducto,idColores);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
