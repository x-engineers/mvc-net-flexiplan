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
   public class NivelEducacionBlo : GenericBlo<crmNivelEducacion>, INivelEducacionBlo
   {
       private INivelEducacionDao _nivelEducacionDao;
       
          public NivelEducacionBlo(INivelEducacionDao nivelEducacionDao)
          : base(nivelEducacionDao)
          {
              _nivelEducacionDao =nivelEducacionDao;
          }
   }
}
