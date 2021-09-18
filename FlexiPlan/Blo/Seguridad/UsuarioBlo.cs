using Dao.Seguridad;
using log4net;
using Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blo.Seguridad
{
    public class UsuarioBlo:IUsuarioBlo
    {
        /// <summary>
        /// Instancia de la clase
        /// </summary>
        private IUsuarioDao _usuarioDao;

        /// <summary>
        /// Constructor que permite la inyección de dependencias en lo 
        /// referente al acceso a datos
        /// </summary>
        [Inject]
        public UsuarioBlo(IUsuarioDao usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        /// <summary>
        /// Propiedad para administrar el mecanismo de logeo 
        /// de informacion y fallas
        /// </summary>
        public static readonly ILog log = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Metodo que permite valdiar las credenciales de un usuario especifico
        /// </summary>
        /// <param name="usuario">Código de Usuario</param>
        /// <param name="clave">Clave de Usuario</param>
        /// <param name="idEmpresa">IdEmpresa</param>
        /// <returns>Usuario Encontrado</returns>
        public List<Usuario> ValidarUsuario(string usuario, string clave, long idEmpresa)
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                lista = _usuarioDao.ValidarUsuario(usuario,clave,idEmpresa);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
