using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Seguridad
{
    public class SucursalDao : GenericDao<Sucursal>, ISucursalDao
    {
        /// <summary>
        /// Metodo que permite obtener todas las agencias por empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de sucursales</returns>
        public List<Sucursal> GetSucursalxEmpresa(long idEmpresa)
        {
            List<Sucursal> lista = new List<Sucursal>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                lista = _SQLBDEntities.Sucursal.AsNoTracking()
                        .Where(x => x.IdEmpresa == idEmpresa && x.IdTipoSucursal==2)
                        .ToList();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
