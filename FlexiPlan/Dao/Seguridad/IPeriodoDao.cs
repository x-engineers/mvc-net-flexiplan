using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Seguridad
{
    public interface IPeriodoDao : IGenericDao<Periodo>
    {
        /// <summary>
        /// Metodo que permite obtener todos los periodos activos de una empresa
        /// </summary>
        /// <param name="idEmpresa">Código de empresa</param>
        /// <returns>Lista de periodos</returns>
        List<Periodo> GetPeriodoActivosxEmpresa(long idEmpresa);
    }
}

