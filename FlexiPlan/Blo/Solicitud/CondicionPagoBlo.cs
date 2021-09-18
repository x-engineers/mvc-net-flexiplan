using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Solicitud;
using log4net;
using System.Reflection;

namespace Blo.Solicitud
{
   public class CondicionPagoBlo : ICondicionPagoBlo
   {
       private ICondicionPagoDao _condicionPagoDao;
       
          public CondicionPagoBlo(ICondicionPagoDao condicionPagoDao)
          {
              _condicionPagoDao = condicionPagoDao;
          }

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
            try
            {
                lista = _condicionPagoDao.GetCondicionesPago(idEmpresa);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
