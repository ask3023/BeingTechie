using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCustomOwin.Infrastructure
{
    public class CultureMiddleware
    {
        private RequestDelegate _next;
        private CultureMiddlewareOptions _options;
        public CultureMiddleware(RequestDelegate next, CultureMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            string culture = context.Request.Query["culture"];

            if (!string.IsNullOrWhiteSpace(culture))
            {
                CultureInfo cultureInfo = new CultureInfo(culture);

                CultureInfo.CurrentCulture = cultureInfo;
            }
            else
            {
                CultureInfo.CurrentCulture = _options.DefaultCulture;
            }

            return _next(context);
        }
    }

    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddlware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseCultureMiddlware(new CultureMiddlewareOptions() { DefaultCulture = new CultureInfo("en-GB") });
        }

        public static IApplicationBuilder UseCultureMiddlware(this IApplicationBuilder appBuilder, CultureMiddlewareOptions options)
        {
            return appBuilder.UseMiddleware<CultureMiddleware>(options);
        }
    }
}
