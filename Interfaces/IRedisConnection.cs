using StackExchange.Redis;

namespace SteamDesktop.Interfaces;

public interface IRedisConnection
{
    public IDatabase getConnection();
}