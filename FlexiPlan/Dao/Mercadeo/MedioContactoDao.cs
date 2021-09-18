using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Mercadeo
{
    public class MedioContactoDao : GenericDao<crmMedioContacto>, IMedioContactoDao
    {
        /// <summary>
        /// Metodo para obtener los medios de contactos filtrado por el idTipoMedio
        /// </summary>
        /// <param name="idTipoMedio"></param>
        /// <returns>lista de medios de contactos</returns>
        public List<crmMedioContacto> GetMedio(long idTipoMedio)
        {
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            List<crmMedioContacto> lista = new List<crmMedioContacto>();
            try
            {
                lista = _SQLBDEntities.crmMedioContacto.AsNoTracking()
                        .Where(x => x.IdTipoMedio == idTipoMedio )
                        .ToList();
            }
            catch (Exception ex)
            {

                log.Error(ex);
            }

            return lista;
        }
    }
}
