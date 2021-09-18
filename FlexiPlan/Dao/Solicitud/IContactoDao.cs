using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Solicitud
{
    public interface IContactoDao : IGenericDao<crmContacto>
    {
        /// <summary>
        /// Permite obtener los datos del contacto por id de oportunidad
        /// esta solo debera tener un contacto asignado
        /// </summary>
        /// <param name="idOportunidad">Identificador de Oportunidad</param>
        /// <returns>Datos de contacto</returns>
        crmContacto GetContactoXIdOportunidad(long idOportunidad);
    }
}
