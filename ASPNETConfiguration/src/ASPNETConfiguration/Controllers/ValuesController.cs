using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ASPNETConfiguration.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IConfiguration _configuration;
        ConnectionInfo _connectionInfo;
        public ValuesController(IConfiguration configuration, IOptions<ConnectionInfo> connectionInfo)
        {
            _configuration = configuration;
            _connectionInfo = connectionInfo.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // var serverName = _configuration.GetValue<string>("ConnectionInfo:Server");
            var port = _connectionInfo.Port;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
