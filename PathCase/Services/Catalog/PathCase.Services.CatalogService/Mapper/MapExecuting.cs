namespace PathCase.Services.CatalogService.Mapper
{
    using AutoMapper;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Models;

    public class MapExecuting : Profile
    {
        public MapExecuting()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
