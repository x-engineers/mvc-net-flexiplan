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
   public class TipoReferenciaBlo : GenericBlo<crmTipoReferencia>, ITipoReferenciaBlo
   {
       private ITipoReferenciaDao _tipoReferenciaDao;
       
          public TipoReferenciaBlo(ITipoReferenciaDao tipoReferenciaDao)
          : base(tipoReferenciaDao)
          {
              _tipoReferenciaDao =tipoReferenciaDao;
          }
   }
}
