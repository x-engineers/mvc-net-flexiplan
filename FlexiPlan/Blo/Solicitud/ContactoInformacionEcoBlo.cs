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
   public class ContactoInformacionEcoBlo : GenericBlo<crmContactoInformacionEco>, IContactoInformacionEcoBlo
   {
       private IContactoInformacionEcoDao _contactoInformacionEcoDao;
       
          public ContactoInformacionEcoBlo(IContactoInformacionEcoDao contactoInformacionEcoDao)
          : base(contactoInformacionEcoDao)
          {
              _contactoInformacionEcoDao =contactoInformacionEcoDao;
          }
   }
}
