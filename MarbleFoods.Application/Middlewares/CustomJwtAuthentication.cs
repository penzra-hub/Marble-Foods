using MarbleFoods.Domain.Models;
using MarbleFoods.Domain.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class CustomJwtAuthentication
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomJwtAuthentication> _logger;
    private readonly Access _serviceSettings;

    public CustomJwtAuthentication(RequestDelegate next, ILogger<CustomJwtAuthentication> logger, IOptions<Access> securitySettings)
    {
        _next = next;
        _logger = logger;
        _serviceSettings = securitySettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == ("/api/Authentication/login") || context.Request.Path == ("/api/Authentication/register"))
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var result = new ApiResponse<string>
            {
                ResponseCode = "06",
                IsSuccessful = false,
                Message = "Invalid Authorization or Expired token"
            };
            await context.Response.WriteAsJsonAsync(result);
            return;
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _serviceSettings.Issuer,
                ValidAudience = _serviceSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_serviceSettings.ApiKey)),
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            context.User = principal;
        }
        catch (SecurityTokenExpiredException)
        {
            _logger.LogError("Token expired.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var result = new ApiResponse<string>
            {
                ResponseCode = "06",
                IsSuccessful = false,
                Message = "Token is Expired"
            };
            await context.Response.WriteAsJsonAsync(result);
            return;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Token validation failed: {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var result = new ApiResponse<string>
            {
                ResponseCode = "06",
                IsSuccessful = false,
                Message = "Invalid Authorization or Expired token"
            };
            await context.Response.WriteAsJsonAsync(result);
            return;
        }

        await _next(context);
    }
}