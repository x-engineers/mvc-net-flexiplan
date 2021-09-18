using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Mercadeo;

namespace Blo.Mercadeo
{
   public class EmpleadoBlo : GenericBlo<rrhEmpleado>, IEmpleadoBlo
   {
       private IEmpleadoDao _empleadoDao;
       
          public EmpleadoBlo(IEmpleadoDao empleadoDao)
          : base(empleadoDao)
          {
              _empleadoDao =empleadoDao;
          }

        /// <summary>
        /// Metodo que de vuelve la lista de vendedores
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
       public  List<rrhEmpleado> GetVendedores(long idEmpresa)
        {
            return _empleadoDao.GetVendedores(idEmpresa);
        }
    }
}
