namespace PathCase.Services.CatalogService.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
