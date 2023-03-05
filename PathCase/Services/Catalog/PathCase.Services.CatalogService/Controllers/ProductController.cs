namespace PathCase.Services.CatalogService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Services;
    using PathCase.Shared.Shared.CustomController;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _productService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var res = await _productService.GetByIdAsync(Id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto product)
        {
            var res = await _productService.CreateProduct(product);
            return CreateActionResultInstance(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            var res = await _productService.UpdateProduct(product);
            return CreateActionResultInstance(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var res = await _productService.DeleteProduct(Id);
            return CreateActionResultInstance(res);
        }
    }
}
