using Dao.Seguridad;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blo.Seguridad
{
    public class AccesoUsuarioBlo:GenericBlo<AccesoUsuario>,IAccesoUsuarioBlo
    {
        private IAccesoUsuarioDao _accesoUsuarioDao;

        public AccesoUsuarioBlo(IAccesoUsuarioDao accesoUsuarioDao)
        : base(accesoUsuarioDao)
        {
            _accesoUsuarioDao = accesoUsuarioDao;
        }
    }
}
