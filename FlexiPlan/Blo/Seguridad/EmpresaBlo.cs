using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Seguridad;

namespace Blo.Seguridad
{
    public class EmpresaBlo : GenericBlo<Empresa>, IEmpresaBlo
    {
        private IEmpresaDao _empresaDao;

        public EmpresaBlo(IEmpresaDao empresaDao)
        : base(empresaDao)
        {
            _empresaDao = empresaDao;
        }
    }
}
