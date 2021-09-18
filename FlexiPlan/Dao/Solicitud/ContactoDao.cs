using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao.Solicitud
{
    public class ContactoDao : GenericDao<crmContacto>, IContactoDao
    {
        /// <summary>
        /// Permite obtener los datos del contacto por id de oportunidad
        /// esta solo debera tener un contacto asignado
        /// </summary>
        /// <param name="idOportunidad">Identificador de Oportunidad</param>
        /// <returns>Datos de contacto</returns>
        public crmContacto GetContactoXIdOportunidad(long idOportunidad)
        {
            crmContacto contacto = new crmContacto();
            SQLBDEntities _SQLBDEntities = new SQLBDEntities();
            _SQLBDEntities.Configuration.ProxyCreationEnabled = false;
            try
            {
                contacto = _SQLBDEntities.crmContacto.AsNoTracking()
                            .Where(x => x.IdOportunidad == idOportunidad)
                            .Single();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            if (contacto == null)
                contacto = new crmContacto();

            try
            {
                if (contacto.Id == 0)
                {
                    var oportunidad = _SQLBDEntities.crmOportunidad.Where(x => x.Id == idOportunidad).FirstOrDefault();

                    if (oportunidad.IdTipoVenta == 2)
                    {
                        contacto.Nombres = oportunidad.BuroNombres;
                        contacto.Apellidos = oportunidad.BuroApellidos;
                        contacto.DUI = oportunidad.BuroDUI;
                        contacto.NIT = oportunidad.BuroNIT;
                        contacto.Genero = oportunidad.BuroGenero;
                        contacto.Telefono = oportunidad.BuroTelefono.Substring(0, 1) == "2" ? oportunidad.BuroTelefono : "";
                        contacto.Celular = oportunidad.BuroTelefono.Substring(0, 1) == "6" || oportunidad.BuroTelefono.Substring(0, 1) == "7" ? oportunidad.BuroTelefono : "";
                        contacto.Correo = oportunidad.BuroCorreo;
                    }
                    else
                    {
                        contacto.Nombres = oportunidad.Nombre;
                        contacto.Telefono = oportunidad.Telefono.Substring(0, 1) == "2" ? oportunidad.Telefono : "";
                        contacto.Celular = oportunidad.Telefono.Substring(0, 1) == "6" || oportunidad.Telefono.Substring(0, 1) == "7" ? oportunidad.Telefono : "";
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }


            return contacto;
        }


    }
}
