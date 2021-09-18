using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;
using Dao.Solicitud;

namespace Blo.Solicitud
{
    public interface IContactoBlo : IGenericBlo<crmContacto>
    {
        /// <summary>
        /// Permite obtener los datos del contacto por id de oportunidad
        /// esta solo debera tener un contacto asignado
        /// </summary>
        /// <param name="idOportunidad">Identificador de Oportunidad</param>
        /// <returns>Datos de contacto</returns>
        crmContacto GetContactoXIdOportunidad(long idOportunidad);

        /// <summary>
        /// Metodo para guardar toda la campaña con sus configuraciones y productos seleccionados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="campaniaProductos"></param>
        /// <param name="IdSucursales"></param>
        /// <param name="IdColores"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idUsuario"></param>
        void SaveContacto(crmContacto data, List<crmContactoDireccion> direcciones, List<crmContactoReferencia> referencias,
            List<crmContactoInformacionEco> infoEconomica, List<crmContactoArchivos> Archivos, long idEmpresa, long idUsuario, long idSucursal);
    }
}
