using DefaultWebApiSerialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DefaultWebApiSerialization.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/products")]
        public IHttpActionResult GetProducts()
        {
            return Ok(BuildProducts());
        }

        private IEnumerable<Product> BuildProducts()
        {
            var products = new List<Product>();

            var p1 = new Product()
            {
                Id = 1,
                Name = "Pen",
                Price = 5
            };

            var p2 = new Product()
            {
                Id = 2,
                Name = "Book",
                Price = 2
            };

            products.Add(p1);
            products.Add(p2);

            return products;
        }
    }

    
}
