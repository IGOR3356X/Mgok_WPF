using StackExchange.Redis;
using SteamDesktop.Interfaces;

namespace SteamDesktop.RedisConnector;

public class RedisConnect: IRedisConnection
{
    public IDatabase getConnection()
    {
        const string connectionString = "localhost:6379";
        try
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
            return redis.GetDatabase(); // Получаем объект для работы с БД
        }
        catch (Exception e)
        {
            throw new RedisException("Could not connect to redis database", e);
        }
    }
}