using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNETCoreLogging.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        ILogger _logger;
        public EmployeesController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EmployeesController>();
        }

        // GET api/employees
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new InvalidOperationException("Testing global exception logger...");
            return new string[] { "Employee1", "Employee2" };
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/employees
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
