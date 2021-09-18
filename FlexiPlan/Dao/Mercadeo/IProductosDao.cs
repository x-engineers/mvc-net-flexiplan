using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public interface IProductosDao : IGenericDao<InvProducto>
    {
        /// <summary>
        /// Obtener los productos por clase y marca
        /// </summary>
        /// <param name="idEmpresa">Código de Empresa</param>
        /// <param name="idClase">Código de clase producto</param>
        /// <param name="idMarca">Código de marca producto</param>
        /// <returns>Lista de productos</returns>
        IQueryable<dynamic> GetProductosClaseMarca(long idEmpresa, long idClase, long idMarca, long idEstadoProducto, long idNivelPrecio);

        /// <summary>
        /// Permite obtener los productos por marca
        /// </summary>
        /// <param name="idEmpresa">identificador de empresa</param>
        /// <param name="idMarca">Identificador de marca</param>
        /// <returns>Lista de productos</returns>
        IQueryable<dynamic> GetProductosMarca(long idEmpresa, long idMarca);

        /// <summary>
        /// Permite obtener los productos por campaña
        /// </summary>
        /// <param name="idEmpresa">identificador de empresa</param>
        /// <param name="idCampaña">Identificador de campaña</param>
        /// <returns>Lista de productos</returns>
        IQueryable<dynamic> GetProductosCampania(long idEmpresa, long idCampania);

        /// <summary>
        /// Permite obtener los datos de un producto por su Id
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <param name="idProducto">Código de producto</param>
        /// <param name="idNivelPrecio">Código de nivel de losta de precio</param>
        /// <returns>Objeto con datos del prodcuto</returns>
        InvProducto GetDatosProducto(long idEmpresa, long idProducto, long idNivelPrecio);

        /// <summary>
        /// Metodo que permite obtener accesorios y servicios
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <param name="Clase">Descripción de clase (accesorio, servicio)</param>
        /// <returns>Lista de productos</returns>
        List<InvProducto> GetProductosServicioAccesorio(long idEmpresa, string Clase);
    }
}
