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
   public class TipoMedioBlo : GenericBlo<crmTipoMedio>, ITipoMedioBlo
   {
       private ITipoMedioDao _tipoMedioDao;
       
          public TipoMedioBlo(ITipoMedioDao tipoMedioDao)
          : base(tipoMedioDao)
          {
              _tipoMedioDao =tipoMedioDao;
          }
   }
}
