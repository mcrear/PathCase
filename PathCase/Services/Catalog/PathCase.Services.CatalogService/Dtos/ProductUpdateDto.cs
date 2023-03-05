namespace PathCase.Services.CatalogService.Dtos
{
    using System;

    public class ProductUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public decimal Price { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }

        public CategoryDto Category { get; set; }
    }
}
