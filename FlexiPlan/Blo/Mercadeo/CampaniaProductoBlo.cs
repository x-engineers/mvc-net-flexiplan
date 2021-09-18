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
   public class CampaniaProductoBlo : GenericBlo<crmCampaniaProducto>, ICampaniaProductoBlo
   {
       private ICampaniaProductoDao _campaniaProductoDao;
       
          public CampaniaProductoBlo(ICampaniaProductoDao campaniaProductoDao)
          : base(campaniaProductoDao)
          {
              _campaniaProductoDao =campaniaProductoDao;
          }
   }
}
