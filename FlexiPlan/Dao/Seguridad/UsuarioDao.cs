using log4net;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Seguridad
{
    public class UsuarioDao : IUsuarioDao
    {

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
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                lista = _SQLBDEntities.Usuario.Include("AccesoUsuario").AsNoTracking()
                        .Where(x => x.Codigo == usuario.ToUpper() && x.clave == clave && x.AccesoUsuario.Where(a =>a.Acceso).Any() && x.activo)
                        .ToList();

                if (lista.Any())
                {
                    long idUsuario = lista.FirstOrDefault().id;
                    long idPerfil = lista.FirstOrDefault().idperfilenc;

                    lista.FirstOrDefault().AccesoUsuario= _SQLBDEntities.AccesoUsuario.AsNoTracking().Where(a => a.IdEmpresa == idEmpresa && a.Acceso && a.IdUsuario == idUsuario).ToList();
                    lista.FirstOrDefault().PerfilEnc = _SQLBDEntities.PerfilEnc.AsNoTracking().Where(a => a.id == idPerfil).FirstOrDefault();
                   var empleadoxUsuario = _SQLBDEntities.rrhEmpleado.AsNoTracking().Where(a => a.IdEmpresa == idEmpresa && a.IdUsuario == idUsuario).ToList();
                    if (empleadoxUsuario.Any())
                        lista.FirstOrDefault().IdEmpleado = empleadoxUsuario.FirstOrDefault().Id;
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
