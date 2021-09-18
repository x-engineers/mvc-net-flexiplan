using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Seguridad;

namespace Blo.Seguridad
{
   public class SucursalBlo : GenericBlo<Sucursal>, ISucursalBlo
   {
       private ISucursalDao _sucursalDao;
       
          public SucursalBlo(ISucursalDao sucursalDao)
          : base(sucursalDao)
          {
              _sucursalDao =sucursalDao;
          }

        /// <summary>
        /// Metodo que permite obtener todas las agencias por empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de sucursales</returns>
        public List<Sucursal> GetSucursalxEmpresa(long idEmpresa)
        {
            List<Sucursal> lista = new List<Sucursal>();
            try
            {
                lista = _sucursalDao.GetSucursalxEmpresa(idEmpresa);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
