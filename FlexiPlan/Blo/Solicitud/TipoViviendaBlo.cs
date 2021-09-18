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
    public class TipoViviendaBlo : GenericBlo<crmTipoVivienda>, ITipoViviendaBlo
    {
        private ITipoViviendaDao _tipoViviendaDao;

        public TipoViviendaBlo(ITipoViviendaDao tipoViviendaDao)
        : base(tipoViviendaDao)
        {
            _tipoViviendaDao = tipoViviendaDao;
        }
    }
}
