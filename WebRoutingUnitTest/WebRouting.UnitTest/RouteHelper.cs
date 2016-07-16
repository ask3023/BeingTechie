using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Unity.WebApi;

namespace WebRouting.UnitTest
{
    public class RouteHelper
    {
        private static RouteHelper _instance;

        private HttpClient _client;

        public HttpConfiguration Config { get; private set; }

        public UnityContainer Resolver { get; private set; }

        public static RouteHelper Create()
        {
            if (_instance == null)
            {
                _instance = new RouteHelper();

                _instance.Config = new HttpConfiguration();
                _instance.Resolver = new UnityContainer();
                _instance.Config.DependencyResolver = new UnityDependencyResolver(_instance.Resolver);
                WebRouting.WebApiConfig.Register(_instance.Config);

                var server = new HttpServer(_instance.Config);

                _instance._client = new HttpClient(server);
                _instance._client.BaseAddress = new Uri("http://routetest/api");
            }

            return _instance;
        }

        public HttpResponseMessage Get(string url)
        {
            var responseMessage = _client.GetAsync(url).Result;
            return responseMessage;
        }
    }
}
