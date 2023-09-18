using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Category;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : DigitalMenuControllerBase<CategoryModel>
    {
        protected override string Route => "/api/Category/";

        private readonly ILogger<ProductController> _logger;

        public CategoryController(ILogger<ProductController> logger, IServiceCategory serviceCategory)
            :base(serviceCategory)
        {
            _logger = logger;
        }
    }
}
