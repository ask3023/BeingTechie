using System.Linq;
using System.Web.Http;

namespace WebRouting
{
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository prodRepo)
        {
            _productRepository = prodRepo;
        }

        [Route("api/product")]
        public IHttpActionResult Get()
        {
            return Ok(_productRepository.RetrieveProducts());
        }


        [Route("api/product/id")]
        public IHttpActionResult Get(int id)
        {
            var product = _productRepository.RetrieveProducts().FirstOrDefault(p => p.Id == id);
            return Ok(product);
        }

        [Route("api/product")]
        public IHttpActionResult Get1()
        {
            return Ok(_productRepository.RetrieveProducts());
        }
    }
}

