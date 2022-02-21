using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;

namespace Mastery.Example.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterNinjectMvc();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterNinjectMvc() 
            => DependencyResolver.SetResolver(new NinjectResolverMvc(CreateKernel())); //https://gist.github.com/odytrice/582108

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            //https://github.com/ninject/Ninject/wiki/Modules-and-the-Kernel -> Dynamic Module Loading need for Onion Architecture;
            kernel.Load(new[] { "Mastery.Example.*.dll" }); 
        
            return kernel;
        }
    }
}
