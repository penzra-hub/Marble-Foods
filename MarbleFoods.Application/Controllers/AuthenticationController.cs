using MarbleFoods.Application.Services.MFServiceInterface;
using MarbleFoods.Domain.DTOs;
using MarbleFoods.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarbleFoods.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthorisationService _authService;

        public AuthenticationController(IAuthorisationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginReqDto request)
        {
            var loginUser = await _authService.LoginMarbleFoodUser(request);
            return Ok(loginUser);
        }

        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiResponse<dynamic>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            return Ok();
        }
    }
}
