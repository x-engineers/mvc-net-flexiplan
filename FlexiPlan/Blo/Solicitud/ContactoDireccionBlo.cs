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
   public class ContactoDireccionBlo : GenericBlo<crmContactoDireccion>, IContactoDireccionBlo
   {
       private IContactoDireccionDao _contactoDireccionDao;
       
          public ContactoDireccionBlo(IContactoDireccionDao contactoDireccionDao)
          : base(contactoDireccionDao)
          {
              _contactoDireccionDao =contactoDireccionDao;
          }
   }
}
