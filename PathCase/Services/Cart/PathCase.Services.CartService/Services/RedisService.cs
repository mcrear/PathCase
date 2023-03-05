namespace PathCase.Services.CartService.Services
{
    using PathCase.Services.CartService.Configurations;
    using StackExchange.Redis;

    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly IRedisConfigurations _redisConfigurations;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IRedisConfigurations redisConfigurations)
        {
            _redisConfigurations = redisConfigurations;
            _host = _redisConfigurations.Host;
            _port = _redisConfigurations.Port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
