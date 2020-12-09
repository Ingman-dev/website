using System.Threading.Tasks;

namespace IngmanDevelopment.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
