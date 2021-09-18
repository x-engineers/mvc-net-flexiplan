using Ninject.Modules;
using Ninject.Web.Common;
using System.Web;
using System.Security.Principal;
using Blo.Seguridad;
using Blo.Mercadeo;
using Blo.Solicitud;

namespace View.Controllers
{
    public class ViewNinject : NinjectModule
    {
        public override void Load()
        {

            //Seguridad
            Bind<IParametroBlo>().To<ParametroBlo>();
            Bind<IUsuarioBlo>().To<UsuarioBlo>();
            Bind<IOpcionBlo>().To<OpcionBlo>();
            Bind<IEmpresaBlo>().To<EmpresaBlo>();
            Bind<ISucursalBlo>().To<SucursalBlo>();
            Bind<IPeriodoBlo>().To<PeriodoBlo>();
            Bind<IAccesoUsuarioBlo>().To<AccesoUsuarioBlo>();

            //Mercadeo
            Bind<IPreciosDetBlo>().To<PreciosDetBlo>();
            Bind<IExistenciasBlo>().To<ExistenciasBlo>();
            Bind<IClaseBlo>().To<ClaseBlo>();
            Bind<IMarcaBlo>().To<MarcaBlo>();
            Bind<IProductosBlo>().To<ProductosBlo>();
            Bind<ICampaniaBlo>().To<CampaniaBlo>();
            Bind<ICampaniaColorProductoBlo>().To<CampaniaColorProductoBlo>();
            Bind<ICampaniaProdRegaliaBlo>().To<CampaniaProdRegaliaBlo>();
            Bind<ICampaniaProductoBlo>().To<CampaniaProductoBlo>();
            Bind<ICampaniaSucursalBlo>().To<CampaniaSucursalBlo>();
            Bind<ITipoVentaBlo>().To<TipoVentaBlo>();
            Bind<IEstadoProductoBlo>().To<EstadoProductoBlo>();
            Bind<INivelPrecioBlo>().To<NivelPrecioBlo>();
            Bind<IColorBlo>().To<ColorBlo>();
            Bind<ICampaniaProdPartesBlo>().To<CampaniaProdPartesBlo>();
            Bind<IOportunidadBlo>().To<OportunidadBlo>();
            Bind<ITipoMedioBlo>().To<TipoMedioBlo>();
            Bind<IMedioContactoBlo>().To<MedioContactoBlo>();
            Bind<IEmpleadoBlo>().To<EmpleadoBlo>();

            //Solicitud
            Bind<IContactoBlo>().To<ContactoBlo>();
            Bind<ITipoViviendaBlo>().To<TipoViviendaBlo>();
            Bind<ICiudadBlo>().To<CiudadBlo>();
            Bind<INivelEducacionBlo>().To<NivelEducacionBlo>();
            Bind<IProfesionBlo>().To<ProfesionBlo>();
            Bind<IEstadoCivilBlo>().To<EstadoCivilBlo>();
            Bind<IContactoDireccionBlo>().To<ContactoDireccionBlo>();
            Bind<IContactoInformacionEcoBlo>().To<ContactoInformacionEcoBlo>();
            Bind<IContactoReferenciaBlo>().To<ContactoReferenciaBlo>();
            Bind<ITipoReferenciaBlo>().To<TipoReferenciaBlo>();
            Bind<ITipoPropiedadBlo>().To<TipoPropiedadBlo>();
            Bind<IDepartamentoBlo>().To<DepartamentoBlo>();
            Bind<ICondicionPagoBlo>().To<CondicionPagoBlo>();
            Bind<ITasaInteresBlo>().To<TasaInteresBlo>();
            Bind<IContactoArchivosBlo>().To<ContactoArchivosBlo>();
            Bind<ITipoDireccionBlo>().To<TipoDireccionBlo>();
        }
    }
}