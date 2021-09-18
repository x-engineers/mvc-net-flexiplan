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
   public class PreciosDetBlo : GenericBlo<InvListaPrecioDet>, IPreciosDetBlo
   {
       private IPreciosDetDao _preciosDetDao;
       
          public PreciosDetBlo(IPreciosDetDao preciosDetDao)
          : base(preciosDetDao)
          {
              _preciosDetDao =preciosDetDao;
          }
   }
}
