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
   public class MedioContactoBlo : GenericBlo<crmMedioContacto>, IMedioContactoBlo
   {
       private IMedioContactoDao _medioContactoDao;
       
          public MedioContactoBlo(IMedioContactoDao medioContactoDao)
          : base(medioContactoDao)
          {
              _medioContactoDao =medioContactoDao;
          }

        /// <summary>
        /// Metodo para obtener los medios de contactos filtrado por el idTipoMedio
        /// </summary>
        /// <param name="idTipoMedio"></param>
        /// <returns>lista de medios de contactos</returns>
        public List<crmMedioContacto> GetMedio(long idTipoMedio)
        {
            return _medioContactoDao.GetMedio(idTipoMedio);
        }
   }
}
