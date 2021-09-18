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
   public class ContactoReferenciaBlo : GenericBlo<crmContactoReferencia>, IContactoReferenciaBlo
   {
       private IContactoReferenciaDao _contactoReferenciaDao;
       
          public ContactoReferenciaBlo(IContactoReferenciaDao contactoReferenciaDao)
          : base(contactoReferenciaDao)
          {
              _contactoReferenciaDao =contactoReferenciaDao;
          }
   }
}
