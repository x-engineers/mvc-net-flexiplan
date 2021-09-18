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
   public class ClaseBlo : GenericBlo<InvClase>, IClaseBlo
   {
       private IClaseDao _claseDao;
       
          public ClaseBlo(IClaseDao claseDao)
          : base(claseDao)
          {
              _claseDao =claseDao;
          }
   }
}
