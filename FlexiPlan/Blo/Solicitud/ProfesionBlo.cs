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
   public class ProfesionBlo : GenericBlo<crmProfesion>, IProfesionBlo
   {
       private IProfesionDao _profesionDao;
       
          public ProfesionBlo(IProfesionDao profesionDao)
          : base(profesionDao)
          {
              _profesionDao =profesionDao;
          }
   }
}
