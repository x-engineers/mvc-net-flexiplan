using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Reflection;
using log4net;

namespace Dao.Seguridad
{
    public class OpcionDao : IOpcionDao
    {

        /// <summary>
        /// Propiedad para administrar el mecanismo de logeo 
        /// de informacion y fallas
        /// </summary>
        public static readonly ILog log = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Permite optener lista de opciones por perfil
        /// </summary>
        /// <param name="idPerfil">Código de perfil/param>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de opciones</returns>
        public List<opcion> GetOpcionPorPerfil(long idPerfil, long idEmpresa)
        {
            List<opcion> lista = new List<opcion>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                var datos = _SQLBDEntities.PerfilDet.AsNoTracking()
                        .Where(x => x.idPerfilEnc == idPerfil && x.visible)
                        .Select(x => x.idOpcion)
                        .ToList();

                if (datos.Any())
                    lista = _SQLBDEntities.opcion.AsNoTracking()
                            .Where(x => datos.Contains(x.id) && x.activo && x.Origen == 1)
                            .ToList();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
        
        /// <summary>
        /// Metodo que permite obtener datos de opcion por su url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Datos de Opción</returns>
        public opcion GetOpcionPorURL( string url)
        {
            opcion opcion = new opcion();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                opcion = _SQLBDEntities.opcion.AsNoTracking()
                         .Where(x => x.URL == url && x.activo && x.Origen == 1)
                         .FirstOrDefault();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return opcion;
        }
    }
}
