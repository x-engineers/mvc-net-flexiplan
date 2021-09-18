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
   public class EstadoProductoBlo : GenericBlo<InvEstadoProducto>, IEstadoProductoBlo
   {
       private IEstadoProductoDao _estadoProductoDao;
       
          public EstadoProductoBlo(IEstadoProductoDao estadoProductoDao)
          : base(estadoProductoDao)
          {
              _estadoProductoDao =estadoProductoDao;
          }
   }
}
