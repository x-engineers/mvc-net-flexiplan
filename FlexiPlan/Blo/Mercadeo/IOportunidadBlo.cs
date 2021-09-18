using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Blo;

namespace Blo.Mercadeo
{
    public interface IOportunidadBlo : IGenericBlo<crmOportunidad>
    {
        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        IQueryable<dynamic> GetOportunidades(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, string estado = null, long idEmpleado = 0);

        /// <summary>
        /// Obtiene el numero de oportunidades asignadas por empleado
        /// </summary>
        /// <param name="idEmpleado">Código de empleado</param>
        /// <returns>Total de oportunidades asignadas</returns>
        long TotalAsingadas(long idEmpleado);

        /// <summary>
        /// Obtiene la todas las oportunidades en un estado aprobadas u condicionadas
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        IQueryable<dynamic> GetOportunidadesAprobadasCondicionadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, long idEmpleado = 0);

        /// <summary>
        /// Obtiene la todas las oportunidades en un estado especifico por defecto muestra las
        /// que tienen estado pendiente
        /// </summary>
        /// <returns>Lista de oportunidades</returns>
        IQueryable<dynamic> GetSolAsignadas(long idEmpresa, out int total, int? page, int? limit, string sortBy, string direction, string searchString = null, string estado = null, long idEmpleado = 0);



    }
}
