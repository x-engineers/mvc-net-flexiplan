using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Mercadeo
{
    public interface IMedioContactoBlo : IGenericBlo<crmMedioContacto>
    {
        /// <summary>
        /// Metodo para obtener los medios de contactos filtrado por el idTipoMedio
        /// </summary>
        /// <param name="idTipoMedio"></param>
        /// <returns>lista de medios de contactos</returns>
         List<crmMedioContacto> GetMedio(long idTipoMedio);
    }
}
