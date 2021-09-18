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
    public class ProductosBlo : GenericBlo<InvProducto>, IProductosBlo
    {
        private IProductosDao _productosDao;

        public ProductosBlo(IProductosDao productosDao)
        : base(productosDao)
        {
            _productosDao = productosDao;
        }

        /// <summary>
        /// Obtener los productos por clase y marca
        /// </summary>
        /// <param name="idEmpresa">Código de Empresa</param>
        /// <param name="idClase">Código de clase producto</param>
        /// <param name="idMarca">Código de marca producto</param>
        /// <returns>Lista de productos</returns>
        public IQueryable<dynamic> GetProductosClaseMarca(long idEmpresa, long idClase, long idMarca, long idEstadoProducto, long idNivelPrecio)
        {
            IQueryable<dynamic> lista = null;
            try
            {
                lista = _productosDao.GetProductosClaseMarca(idEmpresa, idClase, idMarca, idEstadoProducto, idNivelPrecio);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }

        /// <summary>
        /// Permite obtener los productos por marca
        /// </summary>
        /// <param name="idEmpresa">identificador de empresa</param>
        /// <param name="idMarca">Identificador de marca</param>
        /// <returns>Lista de productos</returns>
        public IQueryable<dynamic> GetProductosMarca(long idEmpresa, long idMarca)
        {
            IQueryable<dynamic> lista = null;
            try
            {
                lista = _productosDao.GetProductosMarca(idEmpresa, idMarca);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
        /// <summary>
        /// Permite obtener los productos por campaña
        /// </summary>
        /// <param name="idEmpresa">identificador de empresa</param>
        /// <param name="idCampaña">Identificador de campaña</param>
        /// <returns>Lista de productos</returns>
        public IQueryable<dynamic> GetProductosCampania(long idEmpresa, long idCampania)
        {
            IQueryable<dynamic> lista = null;
            try
            {
                lista = _productosDao.GetProductosCampania(idEmpresa, idCampania);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }

        /// <summary>
        /// Permite obtener los datos de un producto por su Id
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <param name="idProducto">Código de producto</param>
        /// <param name="idNivelPrecio">Código de nivel de losta de precio</param>
        /// <returns>Objeto con datos del prodcuto</returns>
        public InvProducto GetDatosProducto(long idEmpresa, long idProducto, long idNivelPrecio)
        {
            InvProducto datos = new InvProducto();
            try
            {
                datos = _productosDao.GetDatosProducto(idEmpresa, idProducto, idNivelPrecio);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return datos;
        }

        /// <summary>
        /// Metodo que permite obtener accesorios y servicios
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <param name="Clase">Descripción de clase (accesorio, servicio)</param>
        /// <returns>Lista de productos</returns>
        public List<InvProducto> GetProductosServicioAccesorio(long idEmpresa, string Clase)
        {
            List<InvProducto> lista = new List<InvProducto>();
            try
            {
                lista = _productosDao.GetProductosServicioAccesorio(idEmpresa, Clase);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
