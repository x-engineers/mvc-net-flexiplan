using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Blo.Seguridad
{
    public interface IParametroBlo : IGenericBlo<crmParametro>
    {
        /// <summary>
        /// Obtiene un objeto de tipo SEG_PARAMETRO
        /// </summary>
        /// <param name="codigo">codigo para identificar el parametro</param>
        /// <returns>objeto</returns>
        crmParametro GetParametroByCodigo(string codigo);
    }
}
