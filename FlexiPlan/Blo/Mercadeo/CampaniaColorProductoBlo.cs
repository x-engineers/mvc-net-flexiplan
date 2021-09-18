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
   public class CampaniaColorProductoBlo : GenericBlo<crmCampaniaColorProducto>, ICampaniaColorProductoBlo
   {
       private ICampaniaColorProductoDao _campaniaColorProductoDao;
       
          public CampaniaColorProductoBlo(ICampaniaColorProductoDao campaniaColorProductoDao)
          : base(campaniaColorProductoDao)
          {
              _campaniaColorProductoDao =campaniaColorProductoDao;
          }
   }
}
