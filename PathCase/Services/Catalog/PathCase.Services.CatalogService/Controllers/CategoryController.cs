namespace PathCase.Services.CatalogService.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Models;
    using PathCase.Services.CatalogService.Services;
    using PathCase.Shared.Shared.CustomController;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var res = await _categoryService.GetByIdAsync(Id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            var res = await _categoryService.CreateCategory(category);
            return CreateActionResultInstance(res);
        }
    }
}
