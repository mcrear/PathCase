namespace PathCase.Services.CatalogService.Services
{
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Shared.Shared.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateCategory(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
