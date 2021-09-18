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
   public class ColorBlo : GenericBlo<InvColor>, IColorBlo
   {
       private IColorDao _colorDao;
       
          public ColorBlo(IColorDao colorDao)
          : base(colorDao)
          {
              _colorDao =colorDao;
          }
   }
}
