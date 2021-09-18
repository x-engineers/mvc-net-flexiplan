using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Solicitud
{
    public interface ITasaInteresBlo : IGenericBlo<crmTasaInteres>
    {
        /// <summary>
        /// Permite obtener la tasa de interes por default para el cr�dito
        /// </summary>
        /// <returns>objeto de tasa de interes</returns>
        crmTasaInteres GetDefault();

        /// <summary>
        /// Permite obtener una lista de tasas de intereses activas
        /// </summary>
        /// <returns>Lista de tasas de interes</returns>
        List<crmTasaInteres> GetTasaInteres();
    }
}
