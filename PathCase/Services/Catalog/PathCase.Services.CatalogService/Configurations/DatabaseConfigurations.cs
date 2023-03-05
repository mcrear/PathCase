namespace PathCase.Services.CatalogService.Configurations
{
    public class DatabaseConfigurations : IDatabaseConfigurations
    {
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
