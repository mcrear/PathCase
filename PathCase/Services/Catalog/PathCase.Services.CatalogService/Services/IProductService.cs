namespace PathCase.Services.CatalogService.Services
{
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Shared.Shared.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> CreateProduct(ProductCreateDto newProduct);
        Task<Response<ProductDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> UpdateProduct(ProductUpdateDto updateProduct);
        Task<Response<NoContent>> DeleteProduct(string Id);
    }
}
