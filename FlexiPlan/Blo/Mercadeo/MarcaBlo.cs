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
   public class MarcaBlo : GenericBlo<InvMarca>, IMarcaBlo
   {
       private IMarcaDao _marcaDao;
       
          public MarcaBlo(IMarcaDao marcaDao)
          : base(marcaDao)
          {
              _marcaDao =marcaDao;
          }
   }
}
