using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blo.Seguridad
{
    public interface IUsuarioBlo
    {
        /// <summary>
        /// Metodo que permite valdiar las credenciales de un usuario especifico
        /// </summary>
        /// <param name="usuario">Código de Usuario</param>
        /// <param name="clave">Clave de Usuario</param>
        /// <param name="idEmpresa">IdEmpresa</param>
        /// <returns>Usuario Encontrado</returns>
        List<Usuario> ValidarUsuario(string usuario, string clave, long idEmpresa);
    }
}
