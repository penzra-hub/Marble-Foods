using MarbleFoods.Domain.Models.Request;

namespace MarbleFoods.Infrastructure.Services
{
    public interface IHttpRequestService
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
