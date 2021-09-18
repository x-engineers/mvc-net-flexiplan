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
   public class ContactoArchivosBlo : GenericBlo<crmContactoArchivos>, IContactoArchivosBlo
   {
       private IContactoArchivosDao _contactoArchivosDao;
       
          public ContactoArchivosBlo(IContactoArchivosDao contactoArchivosDao)
          : base(contactoArchivosDao)
          {
              _contactoArchivosDao =contactoArchivosDao;
          }
   }
}
