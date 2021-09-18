using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Solicitud;

namespace Blo.Solicitud
{
   public class DepartamentoBlo : GenericBlo<Estados>, IDepartamentoBlo
   {
       private IDepartamentoDao _departamentoDao;
       
          public DepartamentoBlo(IDepartamentoDao departamentoDao)
          : base(departamentoDao)
          {
              _departamentoDao =departamentoDao;
          }
   }
}
