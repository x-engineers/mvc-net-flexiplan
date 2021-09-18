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
   public class NivelPrecioBlo : GenericBlo<InvNivelPrecio>, INivelPrecioBlo
   {
       private INivelPrecioDao _nivelPrecioDao;
       
          public NivelPrecioBlo(INivelPrecioDao nivelPrecioDao)
          : base(nivelPrecioDao)
          {
              _nivelPrecioDao =nivelPrecioDao;
          }
   }
}
