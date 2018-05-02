using Architecture.Core.Interfaces;
using Architecture.Core.Services;
using Architecture.Infrastructure.Data;
using Autofac;
using Autofac.Integration.WebApi;

namespace Architecture.WebApi.Config
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


            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            return builder.Build();
        }
    }
}