namespace PathCase.Services.CartService.Configurations
{
    public interface IRedisConfigurations
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
