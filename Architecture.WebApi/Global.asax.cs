using System.Web.Http;
using Architecture.WebApi.Config;
using Autofac.Integration.WebApi;

namespace Architecture.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Bootstrapper().BuildContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
