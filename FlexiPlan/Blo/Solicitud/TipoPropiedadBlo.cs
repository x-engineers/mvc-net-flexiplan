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
   public class TipoPropiedadBlo : GenericBlo<crmTipoPropiedad>, ITipoPropiedadBlo
   {
       private ITipoPropiedadDao _tipoPropiedadDao;
       
          public TipoPropiedadBlo(ITipoPropiedadDao tipoPropiedadDao)
          : base(tipoPropiedadDao)
          {
              _tipoPropiedadDao =tipoPropiedadDao;
          }
   }
}
