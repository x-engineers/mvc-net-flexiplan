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
    public class ContactoBlo : GenericBlo<crmContacto>, IContactoBlo
    {
        private IContactoDao _contactoDao;
        private IContactoDireccionDao _contactoDireccionDao;
        private IContactoReferenciaDao _contactoReferenciaDao;
        private IContactoInformacionEcoDao _contactoInformacionEcoDao;
        private IContactoArchivosDao _contactoArchivosDao;

        public ContactoBlo(IContactoDao contactoDao, IContactoDireccionDao contactoDireccionDao, 
            IContactoReferenciaDao contactoReferenciaDao, IContactoInformacionEcoDao contactoInformacionEcoDao, IContactoArchivosDao contactoArchivosDao)
        : base(contactoDao)
        {
            _contactoDao = contactoDao;
            _contactoDireccionDao = contactoDireccionDao;
            _contactoReferenciaDao = contactoReferenciaDao;
            _contactoInformacionEcoDao = contactoInformacionEcoDao;
            _contactoArchivosDao = contactoArchivosDao;
        }

        /// <summary>
        /// Permite obtener los datos del contacto por id de oportunidad
        /// esta solo debera tener un contacto asignado
        /// </summary>
        /// <param name="idOportunidad">Identificador de Oportunidad</param>
        /// <returns>Datos de contacto</returns>
        public crmContacto GetContactoXIdOportunidad(long idOportunidad)
        {
            crmContacto contacto = new crmContacto();
            try
            {
                contacto = _contactoDao.GetContactoXIdOportunidad(idOportunidad);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return contacto;
        }

        /// <summary>
        /// Metodo para guardar toda la campaña con sus configuraciones y productos seleccionados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="campaniaProductos"></param>
        /// <param name="IdSucursales"></param>
        /// <param name="IdColores"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idUsuario"></param>
        public void SaveContacto(crmContacto data, List<crmContactoDireccion> direcciones, List<crmContactoReferencia> referencias,
            List<crmContactoInformacionEco> infoEconomica, List<crmContactoArchivos> Archivos, long idEmpresa, long idUsuario, long idSucursal)
        {
            string mensaje = string.Empty;
            crmContacto contacto = new crmContacto();
            SQLBDEntities _SQLEntities = new SQLBDEntities();
            _SQLEntities.Configuration.ProxyCreationEnabled = false;

            using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
            {
                try
                {
                    if (data.Id != 0)
                    {
                        contacto = _contactoDao.GetById(data.Id);
                        contacto.IdUsuarioModifico = idUsuario;
                        contacto.FechaModifico = DateTime.Now;
                    }
                    else
                    {
                        contacto.IdUsuarioAgrego = idUsuario;
                        contacto.FechaAgrego = DateTime.Now;
                    }

                    contacto.CondIdMarca = data.CondIdMarca;
                    contacto.CondIdNivelPrecio = data.CondIdNivelPrecio;
                    contacto.CondIdProducto = data.CondIdProducto;
                    contacto.CondIdTasaInteres = data.CondIdTasaInteres;
                    contacto.CondIdInvProductoPartes = data.CondIdInvProductoPartes;
                    contacto.CondIdProductoAccesorio = data.CondIdProductoAccesorio;
                    contacto.CondIdProductoParteServio = data.CondIdProductoParteServio;
                    contacto.CondIdInvCondicionPago = data.CondIdInvCondicionPago;
                    contacto.CondTipoDescuento = data.CondTipoDescuento;
                    contacto.CondValorDescuento = data.CondValorDescuento;
                    contacto.CondPrecioActual = data.CondPrecioActual;
                    contacto.CondPrecioNuevo = data.CondPrecioNuevo;
                    contacto.CondTipoPrima = data.CondTipoPrima;
                    contacto.CondvalorPrima = data.CondvalorPrima;
                    contacto.CondGarantia = data.CondGarantia;
                    contacto.CondPrimerCuota = data.CondPrimerCuota;
                    contacto.CondMontoCuotas = data.CondMontoCuotas;
                    contacto.CondMontoFinciado = data.CondMontoFinciado;
                    contacto.CondFechaPrimerPago = data.CondFechaPrimerPago;

                    contacto.IdEmpresa = idEmpresa;
                    contacto.IdSucursal = idSucursal;
                    contacto.IdOportunidad = data.IdOportunidad;
                    contacto.IdCliente = 0;
                    contacto.IdTipoVenta = data.IdTipoVenta;
                    contacto.EsIndependiente = data.EsIndependiente;
                    contacto.NumeroDependientes = data.NumeroDependientes;
                    contacto.Nombres = data.Nombres;
                    contacto.Apellidos = data.Apellidos;
                    contacto.ConocidoPor = data.ConocidoPor;
                    contacto.Genero = data.Genero;
                    contacto.DUI = data.DUI;
                    contacto.NIT = data.NIT;
                    contacto.Correo = data.Correo;
                    contacto.Telefono = data.Telefono;
                    contacto.Celular = data.Celular;
                    contacto.FechaNacimiento = data.FechaNacimiento;
                    contacto.IdCiudad = data.IdCiudad;
                    contacto.Nacionalidad = data.Nacionalidad;
                    contacto.IdNivelEducacion = data.IdNivelEducacion;
                    contacto.IdProfesion = data.IdProfesion;
                    contacto.IdEstadoCivil = data.IdEstadoCivil;
                    contacto.Estado = data.Estado;
                    contacto.ActNombreEmpresa = data.ActNombreEmpresa;
                    contacto.ActActividad = data.ActActividad;
                    contacto.ActIdDepartamento = data.ActIdDepartamento;
                    contacto.ActIdMunicipio = data.ActIdMunicipio;
                    contacto.ActCalle = data.ActCalle;
                    contacto.ActPasaje = data.ActPasaje;
                    contacto.ActColonia = data.ActColonia;
                    contacto.ActNumeroCasa = data.ActNumeroCasa;
                    contacto.ActReferenciaUbicacion = data.ActReferenciaUbicacion;
                    contacto.ActIndDeclaraImpuesto = data.ActIndDeclaraImpuesto;
                    contacto.ActIndAntiguedad = data.ActIndAntiguedad;
                    contacto.ActIndTipoLocal = data.ActIndTipoLocal;
                    contacto.ActIndNumeroEmpleados = data.ActIndNumeroEmpleados;
                    contacto.ActIndTipoSector = data.ActIndTipoSector;
                    contacto.ActIndCantidadLocales = data.ActIndCantidadLocales;
                    contacto.ActIndDireccion2 = data.ActIndDireccion2;
                    contacto.ActIndDireccion3 = data.ActIndDireccion3;
                    contacto.ActIndDireccion4 = data.ActIndDireccion4;
                    contacto.ActDepJefe = data.ActDepJefe;
                    contacto.ActDepFechaIngreso = data.ActDepFechaIngreso;
                    contacto.ActDepTipoContrato = data.ActDepTipoContrato;
                    contacto.ActDepTipoSueldo = data.ActDepTipoSueldo;
                    contacto.ActDepIngresoFijo = data.ActDepIngresoFijo;
                    contacto.ActDepIngresoVariable = data.ActDepIngresoVariable;
                    contacto.ActDepDiaPago = data.ActDepDiaPago;
                    contacto.ActDepFormaPago = data.ActDepFormaPago;
                    contacto.ActDepCargo = data.ActDepCargo;
                    contacto.ActDepTelefono = data.ActDepTelefono;
                    contacto.ActDepCelular = data.ActDepCelular;
                    contacto.ConyugeNombres = data.ConyugeNombres;
                    contacto.ConyugeApellidos = data.ConyugeApellidos;
                    contacto.ConyugeConocidoPor = data.ConyugeConocidoPor;
                    contacto.ConyugeGenero = data.ConyugeGenero;
                    contacto.ConyugeEmpresa = data.ConyugeEmpresa;
                    contacto.ConyugeActividadEmpresa = data.ConyugeActividadEmpresa;
                    contacto.ConyugeCargoEmpresa = data.ConyugeCargoEmpresa;
                    contacto.ConyugeTelefonoEmpresa = data.ConyugeTelefonoEmpresa;
                    contacto.ConyugeIngresoMensual = data.ConyugeIngresoMensual;
                    contacto.ConyugeFechaIngreso = data.ConyugeFechaIngreso;
                    contacto.Estado = crmContacto.ESTADO_PENDIENTE;
                    _contactoDao.Save(contacto);



                    if (data.Id != 0)
                    {
                        //eliminar Archivos que ya no estan
                        foreach (var item in _SQLEntities.crmContactoArchivos.AsNoTracking().Where(x => x.IdContacto == data.Id))
                        {
                            _contactoArchivosDao.Remove(item.Id);
                        }

                        //eliminar direcciones que ya no estan
                        List<long> idsDirecciones = direcciones.Select(d => d.Id).ToList();
                        foreach (var item in _SQLEntities.crmContactoDireccion.AsNoTracking().Where(x => !idsDirecciones.Contains(x.Id) && x.IdContacto == data.Id))
                        {
                            _contactoDireccionDao.Remove(item.Id);
                        }

                        //eliminar referencias que ya no estan
                        List<long> idsRererencias = referencias.Select(d => d.Id).ToList();
                        foreach (var item in _SQLEntities.crmContactoReferencia.AsNoTracking().Where(x => !idsRererencias.Contains(x.Id) && x.IdContacto == data.Id))
                        {
                            _contactoReferenciaDao.Remove(item.Id);
                        }

                        //eliminar información económica que ya no estan
                        List<long> idsinfoEconomica = infoEconomica.Select(d => d.Id).ToList();
                        foreach (var item in _SQLEntities.crmContactoInformacionEco.AsNoTracking().Where(x => !idsinfoEconomica.Contains(x.Id) && x.IdContacto == data.Id))
                        {
                            _contactoInformacionEcoDao.Remove(item.Id);
                        }
                    }

                    foreach (var item in Archivos)
                    {
                        crmContactoArchivos archivo = new crmContactoArchivos();

                        archivo.IdEmpresa = idEmpresa;
                        archivo.IdContacto = contacto.Id;
                        archivo.Nombre = item.Nombre;
                        archivo.Tipo = item.Tipo;
                        archivo.Archivo = item.Archivo;

                        _contactoArchivosDao.Save(archivo);
                    }

                    //agregar direcciones
                    foreach (var item in direcciones)
                    {
                        crmContactoDireccion direccion = new crmContactoDireccion();

                        if (data.Id > 0 && item.Id > 0)
                            direccion = _contactoDireccionDao.GetById(item.Id);


                        direccion.IdEmpresa = idEmpresa;
                        direccion.IdContacto = contacto.Id;
                        direccion.IdDepartamento = item.IdDepartamento;
                        direccion.IdMunicipio = item.IdMunicipio;
                        direccion.Direccion = item.Direccion;
                        direccion.DirReferencia = item.DirReferencia;
                        direccion.IdTipoVivienda = item.IdTipoVivienda;
                        direccion.IdTipoDireccion = item.IdTipoDireccion;
                        direccion.TiempoResidenciaMeses = item.TiempoResidenciaMeses;
                        direccion.Comentario = item.Comentario;
                        direccion.Valida = item.Valida;
                        direccion.FechaValida = item.FechaValida;

                        _contactoDireccionDao.Save(direccion);
                    }

                    //agregar referencias
                    foreach (var item in referencias)
                    {
                        crmContactoReferencia referencia = new crmContactoReferencia();

                        if (data.Id > 0 && item.Id > 0)
                            referencia = _contactoReferenciaDao.GetById(item.Id);


                        referencia.IdEmpresa = idEmpresa;
                        referencia.IdContacto = contacto.Id;
                        referencia.Nombres = item.Nombres;
                        referencia.Apellidos = item.Apellidos;
                        referencia.Parentesco = item.Parentesco;
                        referencia.IdTipoReferencia = item.IdTipoReferencia;
                        referencia.Telefono = item.Telefono;
                        referencia.Valida = item.Valida;
                        referencia.FechaValida = item.FechaValida;

                        _contactoReferenciaDao.Save(referencia);
                    }

                    //agregar información económica
                    foreach (var item in infoEconomica)
                    {
                        crmContactoInformacionEco info = new crmContactoInformacionEco();

                        if (data.Id > 0 && item.Id > 0)
                            info = _contactoInformacionEcoDao.GetById(item.Id);

                        info.IdEmpresa = idEmpresa;
                        info.IdContacto = contacto.Id;
                        info.IdTipoPropiedad = item.IdTipoPropiedad;
                        info.Nombre = item.Nombre;
                        info.Valor = item.Valor;
                        info.Descripcion = item.Descripcion;
                        info.Valida = item.Valida;
                        info.FechaValida = item.FechaValida;

                        _contactoInformacionEcoDao.Save(info);
                    }

                    scope.Complete();
                }
                catch (Exception e)
                {
                    log.Error(e);
                    mensaje = "El contacto no fue guardada, revisar log.error";
                }
            }

            //Notificar de posibles errores
            if (!string.IsNullOrEmpty(mensaje))
                throw new Exception(mensaje);
        }
    }
}
