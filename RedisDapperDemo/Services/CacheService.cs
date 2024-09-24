using Dapr.Client;
using RedisDapperDemo.Contacts;

namespace RedisDapperDemo.Services
{
    public class CacheService : ICacheService
    {
        private readonly DaprClient _daprClient;

        public CacheService(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task SetCacheAsync(string key, object value)
        {
            await _daprClient.SaveStateAsync("statestore", key, value);
        }

        public async Task<T> GetCacheAsync<T>(string key)
        {
            return await _daprClient.GetStateAsync<T>("statestore", key);
        }

        public async Task DeleteCacheAsync(string key)
        {
            await _daprClient.DeleteStateAsync("statestore", key);
        }
    }
}
