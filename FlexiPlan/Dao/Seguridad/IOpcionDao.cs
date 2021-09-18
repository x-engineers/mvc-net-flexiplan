using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Seguridad
{
    public interface IOpcionDao
    {
        /// <summary>
        /// Permite optener lista de opciones por perfil
        /// </summary>
        /// <param name="idPerfil">Código de perfil/param>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de opciones</returns>
        List<opcion> GetOpcionPorPerfil(long idPerfil, long idEmpresa);

        /// <summary>
        /// Metodo que permite obtener datos de opcion por su url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Datos de Opción</returns>
        opcion GetOpcionPorURL(string url);
    }
}
