using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Model;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public async IAsyncEnumerable<Product> Get()
        {
            await foreach (var product in _productRepository.GetAllProductsAsync().Result)
            {
                yield return product;
            };
        }


    }
}