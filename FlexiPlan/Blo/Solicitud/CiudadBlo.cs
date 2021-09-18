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
   public class CiudadBlo : GenericBlo<Ciudades>, ICiudadBlo
   {
       private ICiudadDao _ciudadDao;
       
          public CiudadBlo(ICiudadDao ciudadDao)
          : base(ciudadDao)
          {
              _ciudadDao =ciudadDao;
          }
   }
}
