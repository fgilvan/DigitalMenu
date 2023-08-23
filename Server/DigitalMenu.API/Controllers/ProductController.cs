using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Product;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : DigitalMenuControllerBase<ProductModel>
    {
        protected override string Route => "/api/Product/";

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IServiceProduct serviceProduct)
            :base(serviceProduct)
        {
            _logger = logger;
        }
    }
}
