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
   public class ExistenciasBlo : GenericBlo<InvExistencia>, IExistenciasBlo
   {
       private IExistenciasDao _existenciasDao;
       
          public ExistenciasBlo(IExistenciasDao existenciasDao)
          : base(existenciasDao)
          {
              _existenciasDao =existenciasDao;
          }
   }
}
