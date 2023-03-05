namespace PathCase.Services.CatalogService
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PathCase.Services.CatalogService.Dtos;
    using PathCase.Services.CatalogService.Services;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var categoryService = serviceProvider.GetRequiredService<ICategoryService>();

                if (!categoryService.GetAllAsync().Result.Data.Any())
                {
                    categoryService.CreateCategory(new CategoryDto { Name = "T-Shirt" }).Wait();
                    categoryService.CreateCategory(new CategoryDto { Name = "Sweet" }).Wait();

                    var categories = categoryService.GetAllAsync().Result.Data;

                    var productService = serviceProvider.GetRequiredService<IProductService>();

                    decimal price = 0;
                    foreach (var item in categories)
                    {
                        price += 10;
                        productService.CreateProduct(
                            new ProductCreateDto
                            {
                                CategoryId = item.Id,
                                CreatedDate = DateTime.Now,
                                Name = $"Mavi {item.Name}",
                                Picture = "NoImage",
                                Price = price + 2
                            }).Wait();

                        productService.CreateProduct(
                            new ProductCreateDto
                            {
                                CategoryId = item.Id,
                                CreatedDate = DateTime.Now,
                                Name = $"Kırmızı {item.Name}",
                                Picture = "NoImage",
                                Price = price + 4
                            }).Wait();

                        productService.CreateProduct(
                            new ProductCreateDto
                            {
                                CategoryId = item.Id,
                                CreatedDate = DateTime.Now,
                                Name = $"Beyaz {item.Name}",
                                Picture = "NoImage",
                                Price = price
                            }).Wait();

                        productService.CreateProduct(
                            new ProductCreateDto
                            {
                                CategoryId = item.Id,
                                CreatedDate = DateTime.Now,
                                Name = $"Siyah {item.Name}",
                                Picture = "NoImage",
                                Price = price + 5
                            }).Wait();
                    }
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
