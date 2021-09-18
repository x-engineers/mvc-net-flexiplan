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
    public class TipoDireccionBlo : GenericBlo<crmTipoDireccion>, ITipoDireccionBlo
    {
        private ITipoDireccionDao _tipoDireccionDao;

        public TipoDireccionBlo(ITipoDireccionDao tipoDireccionDao)
        : base(tipoDireccionDao)
        {
            _tipoDireccionDao = tipoDireccionDao;
        }
    }
}
