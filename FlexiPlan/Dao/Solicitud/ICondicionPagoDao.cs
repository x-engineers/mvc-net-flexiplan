using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Solicitud
{
    public interface ICondicionPagoDao 
    {

        /// <summary>
        /// Metodo que permite obtener las condiciones de pago o plazos para la venta al credito
        /// </summary>
        /// <returns>Lista de condicones de  pago o plazos</returns>
        List<InvCondicionPago> GetCondicionesPago(long idEmpresa);
    }
}
