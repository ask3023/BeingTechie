using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Unity.WebApi;
using Microsoft.Practices.Unity;

[assembly: OwinStartup(typeof(WebRouting.Startup))]

namespace WebRouting
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var config = GlobalConfiguration.Configuration;
            Initialize(config);   

            app.UseWebApi(config);

            config.EnsureInitialized();
        }

        private void Initialize(HttpConfiguration config)
        {
            WebApiConfig.Register(config);

            config.DependencyResolver = new UnityDependencyResolver(BuildContainer());
        }

        private UnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepository>();

            return container;
        }

    }
}
