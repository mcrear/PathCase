namespace PathCase.Services.CatalogService.Services
{
    using AutoMapper;
    using MongoDB.Driver;
    using PathCase.Services.CatalogService.Configurations;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Models;
    using PathCase.Shared.Shared.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseConfigurations databaseConfigurations)
        {
            var client = new MongoClient(databaseConfigurations.ConnectionString);
            var db = client.GetDatabase(databaseConfigurations.DatabaseName);

            _categoryCollection = db.GetCollection<Category>(databaseConfigurations.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();

            if (category == null)
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            else
                return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
