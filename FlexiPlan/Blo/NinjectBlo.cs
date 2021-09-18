using Dao.Seguridad;
using Dao.Mercadeo;
using Ninject.Modules;
using Dao.Solicitud;

namespace BLO
{
    public class NinjectBlo : NinjectModule
    {
        public override void Load()
        {
            //Seguridad
            Bind<IParametroDao>().To<ParametroDao>();
            Bind<IUsuarioDao>().To<UsuarioDao>();
            Bind<IOpcionDao>().To<OpcionDao>();
            Bind<IEmpresaDao>().To<EmpresaDao>();
            Bind<ISucursalDao>().To<SucursalDao>();
            Bind<IPeriodoDao>().To<PeriodoDao>();
            Bind<IAccesoUsuarioDao>().To<AccesoUsuarioDao>();

            //Mercadeo
            Bind<IPreciosDetDao>().To<PreciosDetDao>();
            Bind<IExistenciasDao>().To<ExistenciasDao>();
            Bind<IClaseDao>().To<ClaseDao>();
            Bind<IMarcaDao>().To<MarcaDao>();
            Bind<IProductosDao>().To<ProductosDao>();
            Bind<ICampaniaDao>().To<CampaniaDao>();
            Bind<ICampaniaColorProductoDao>().To<CampaniaColorProductoDao>();
            Bind<ICampaniaProdRegaliaDao>().To<CampaniaProdRegaliaDao>();
            Bind<ICampaniaProductoDao>().To<CampaniaProductoDao>();
            Bind<ICampaniaSucursalDao>().To<CampaniaSucursalDao>();
            Bind<ITipoVentaDao>().To<TipoVentaDao>();
            Bind<IEstadoProductoDao>().To<EstadoProductoDao>();
            Bind<INivelPrecioDao>().To<NivelPrecioDao>();
            Bind<IColorDao>().To<ColorDao>();
            Bind<ICampaniaProdPartesDao>().To<CampaniaProdPartesDao>();
            Bind<IOportunidadDao>().To<OportunidadDao>();
            Bind<ITipoMedioDao>().To<TipoMedioDao>();
            Bind<IMedioContactoDao>().To<MedioContactoDao>();
            Bind<IEmpleadoDao>().To<EmpleadoDao>();

            //Solicitud
            Bind<IContactoDao>().To<ContactoDao>();
            Bind<ITipoViviendaDao>().To<TipoViviendaDao>();
            Bind<ICiudadDao>().To<CiudadDao>();
            Bind<INivelEducacionDao>().To<NivelEducacionDao>();
            Bind<IProfesionDao>().To<ProfesionDao>();
            Bind<IEstadoCivilDao>().To<EstadoCivilDao>();
            Bind<IContactoDireccionDao>().To<ContactoDireccionDao>();
            Bind<IContactoInformacionEcoDao>().To<ContactoInformacionEcoDao>();
            Bind<IContactoReferenciaDao>().To<ContactoReferenciaDao>();
            Bind<ITipoReferenciaDao>().To<TipoReferenciaDao>();
            Bind<ITipoPropiedadDao>().To<TipoPropiedadDao>();
            Bind<IDepartamentoDao>().To<DepartamentoDao>();
            Bind<ICondicionPagoDao>().To<CondicionPagoDao>();
            Bind<ITasaInteresDao>().To<TasaInteresDao>();
            Bind<IContactoArchivosDao>().To<ContactoArchivosDao>();
            Bind<ITipoDireccionDao>().To<TipoDireccionDao>();

        }
    }
}