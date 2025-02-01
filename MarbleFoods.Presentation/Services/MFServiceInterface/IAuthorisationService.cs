using MarbleFoods.Domain.DTOs;
using MarbleFoods.Domain.Models.Response;

namespace MarbleFoods.Application.Services.MFServiceInterface
{
    public interface IAuthorisationService
    {
        Task<ApiResponse<string>> LoginMarbleFoodUser(LoginReqDto request);
    }
}
