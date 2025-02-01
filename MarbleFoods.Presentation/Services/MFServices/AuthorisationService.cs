using FluentValidation;
using MarbleFoods.Application.Services.MFServiceInterface;
using MarbleFoods.Domain.DTOs;
using MarbleFoods.Domain.Models.Response;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MarbleFoods.Application.Services.MFServices
{
    public class AuthorisationService : IAuthorisationService
    {
        private readonly IValidator<LoginReqDto> _loginValidator;
        private readonly ILogger<AuthorisationService> _logger;
        public AuthorisationService(IValidator<LoginReqDto> loginValidator, ILogger<AuthorisationService> logger)
        {
            _loginValidator = loginValidator;
            _logger = logger;
        }

        public Task<ApiResponse<string>> LoginMarbleFoodUser(LoginReqDto request)
        {
            _logger.LogInformation("Login has been initiated!");
            var validate = _loginValidator.Validate(request);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            throw new NotImplementedException();
        }
    }
}
