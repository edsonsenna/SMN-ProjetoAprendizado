using Api.App_Start;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;

namespace Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
