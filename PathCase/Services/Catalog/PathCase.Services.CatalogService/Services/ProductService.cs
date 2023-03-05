namespace PathCase.Services.CatalogService.Services
{
    using AutoMapper;
    using MongoDB.Driver;
    using PathCase.Services.CatalogService.Configurations;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Models;
    using PathCase.Shared.Shared.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseConfigurations databaseConfigurations)
        {
            var client = new MongoClient(databaseConfigurations.ConnectionString);
            var db = client.GetDatabase(databaseConfigurations.DatabaseName);

            _productCollection = db.GetCollection<Product>(databaseConfigurations.ProductCollectionName);
            _categoryCollection = db.GetCollection<Category>(databaseConfigurations.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(Product => true).ToListAsync();

            if (products.Any())
                foreach (var item in products)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
                }
            else
                products = new List<Product>();
            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<Response<ProductDto>> CreateProduct(ProductCreateDto newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            product.CreatedDate = DateTime.Now;
            await _productCollection.InsertOneAsync(product);
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
                return Response<ProductDto>.Fail("Product Not Found", 404);

            product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstAsync();
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<Response<NoContent>> UpdateProduct(ProductUpdateDto updateProduct)
        {
            var product = _mapper.Map<Product>(updateProduct);

            var res = await _productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);

            if (res == null)
            {
                return Response<NoContent>.Fail("Course Not Found", 404);
            }
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteProduct(string Id)
        {
            var res = await _productCollection.DeleteOneAsync(x => x.Id == Id);

            if (res.DeletedCount > 0)
                return Response<NoContent>.Success(204);
            else
                return Response<NoContent>.Fail("Course Not Found", 404);
        }
    }
}
