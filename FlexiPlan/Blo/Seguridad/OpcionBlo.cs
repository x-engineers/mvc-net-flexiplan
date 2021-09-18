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
    public class OpcionBlo:IOpcionBlo
    {
        /// <summary>
        /// Instancia de la clase
        /// </summary>
        private  IOpcionDao _opcionDao;

        /// <summary>
        /// Constructor que permite la inyección de dependencias en lo 
        /// referente al acceso a datos
        /// </summary>
        [Inject]
        public OpcionBlo(IOpcionDao opcionDao)
        {
            _opcionDao = opcionDao;
        }

        /// <summary>
        /// Propiedad para administrar el mecanismo de logeo 
        /// de informacion y fallas
        /// </summary>
        public static readonly ILog log = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Permite optener lista de opciones por perfil
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de opciones</returns>
        public List<opcion> GetOpcionPorPerfil(long idPerfil,long idEmpresa)
        {
            List<opcion> lista = new List<opcion>();
            try
            {
                lista = _opcionDao.GetOpcionPorPerfil(idPerfil,idEmpresa);
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
        public opcion GetOpcionPorURL(string url)
        {
            opcion opcion = new opcion();
            try
            {
                opcion = _opcionDao.GetOpcionPorURL(url);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return opcion;
        }
    }
}
