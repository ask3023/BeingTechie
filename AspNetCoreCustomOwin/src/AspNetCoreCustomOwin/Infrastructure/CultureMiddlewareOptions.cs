using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCustomOwin.Infrastructure
{
    public class CultureMiddlewareOptions
    {
        public CultureInfo DefaultCulture { get; set; }
    }
}
