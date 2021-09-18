using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Reflection;
using log4net;

namespace Dao.Solicitud
{
    public class CondicionPagoDao : ICondicionPagoDao
    {
        /// <summary>
        /// Propiedad para administrar el mecanismo de logeo 
        /// de informacion y fallas
        /// </summary>
        public static readonly ILog log = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Metodo que permite obtener las condiciones de pago o plazos para la venta al credito
        /// </summary>
        /// <returns>Lista de condicones de  pago o plazos</returns>
        public List<InvCondicionPago> GetCondicionesPago(long idEmpresa)
        {
            List<InvCondicionPago> lista = new List<InvCondicionPago>();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
               lista = _SQLBDEntities.InvCondicionPago.AsNoTracking()
                        .Where(x => x.Agregar > 0 && x.IdInvTipoMov == 1 && x.IdEmpresa == idEmpresa)
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
