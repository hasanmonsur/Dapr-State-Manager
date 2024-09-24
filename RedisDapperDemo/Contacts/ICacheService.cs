namespace RedisDapperDemo.Contacts
{
    public interface ICacheService
    {
        Task DeleteCacheAsync(string key);
        Task<T> GetCacheAsync<T>(string key);
        Task SetCacheAsync(string key, object value);
    }
}