namespace PathCase.Services.CartService.Configurations
{
    public class RedisConfigurations : IRedisConfigurations
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}