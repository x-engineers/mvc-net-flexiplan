﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject;
using Dao.Seguridad;

namespace Blo.Seguridad
{
    public class ParametroBlo : GenericBlo<crmParametro>, IParametroBlo
    {
        /// <summary>
        /// Instancia de la clase
        /// </summary>
        private IParametroDao _parametroDao;

        /// <summary>
        /// Constructor que permite la inyección de dependencias en lo 
        /// referente al acceso a datos
        /// </summary>
        [Inject]
        public ParametroBlo(IParametroDao parametroDao)
            : base(parametroDao)
        {
            _parametroDao = parametroDao;
        }

        /// <summary>
        /// Obtiene un objeto de tipo SEG_PARAMETRO
        /// </summary>
        /// <param name="codigo">codigo para identificar el parametro</param>
        /// <returns>objeto</returns>
        public crmParametro GetParametroByCodigo(string codigo)
        {
            crmParametro lista = new crmParametro();
            try
            {
                lista = _parametroDao.GetParametroByCodigo(codigo);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return lista;
        }
    }
}
