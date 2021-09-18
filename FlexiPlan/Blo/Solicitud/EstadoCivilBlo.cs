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
   public class EstadoCivilBlo : GenericBlo<EstadoCivil>, IEstadoCivilBlo
   {
       private IEstadoCivilDao _estadoCivilDao;
       
          public EstadoCivilBlo(IEstadoCivilDao estadoCivilDao)
          : base(estadoCivilDao)
          {
              _estadoCivilDao =estadoCivilDao;
          }
   }
}
