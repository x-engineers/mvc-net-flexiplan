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
   public class CampaniaSucursalBlo : GenericBlo<crmCampaniaSucursal>, ICampaniaSucursalBlo
   {
       private ICampaniaSucursalDao _campaniaSucursalDao;
       
          public CampaniaSucursalBlo(ICampaniaSucursalDao campaniaSucursalDao)
          : base(campaniaSucursalDao)
          {
              _campaniaSucursalDao =campaniaSucursalDao;
          }
   }
}
