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
   public class CampaniaProdRegaliaBlo : GenericBlo<crmCampaniaProdRegalia>, ICampaniaProdRegaliaBlo
   {
       private ICampaniaProdRegaliaDao _campaniaProdRegaliaDao;
       
          public CampaniaProdRegaliaBlo(ICampaniaProdRegaliaDao campaniaProdRegaliaDao)
          : base(campaniaProdRegaliaDao)
          {
              _campaniaProdRegaliaDao =campaniaProdRegaliaDao;
          }
   }
}
