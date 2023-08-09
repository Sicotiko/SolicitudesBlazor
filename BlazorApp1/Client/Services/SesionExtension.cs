using Blazored.SessionStorage;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public static class SesionExtension
    {

        public static async Task SaveStorage<T>(this ISessionStorageService sessionService, string key, T item) where T : class
        {
            var itemJson = JsonSerializer.Serialize(item);
            await sessionService.SetItemAsStringAsync(key, itemJson);
        }
        public static async Task<T?> GetStorage<T>(this ISessionStorageService sessionService, string key) where T : class
        {
            var itemJson = await sessionService.GetItemAsStringAsync(key);
            if (itemJson != null)
                return JsonSerializer.Deserialize<T>(itemJson);
            else
                return null;
        }

    }
}
