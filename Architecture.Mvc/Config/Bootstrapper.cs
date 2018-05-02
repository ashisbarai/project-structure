using Architecture.Core.Interfaces;
using Architecture.Core.Services;
using Architecture.Infrastructure.Data;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Architecture.Web.Config
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<EmployeeService>().AsSelf().InstancePerRequest();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            return builder.Build();
        }
    }
}