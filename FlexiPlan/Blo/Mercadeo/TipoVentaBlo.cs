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
   public class TipoVentaBlo : GenericBlo<crmTipoVenta>, ITipoVentaBlo
   {
       private ITipoVentaDao _tipoVentaDao;
       
          public TipoVentaBlo(ITipoVentaDao tipoVentaDao)
          : base(tipoVentaDao)
          {
              _tipoVentaDao =tipoVentaDao;
          }
   }
}
