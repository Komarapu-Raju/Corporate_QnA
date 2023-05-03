using AutoMapper;
using CorporateQnA.Core.Models;
using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Services;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("authorization/")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;

        public readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            this._authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            var result = await this._authService.Register(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await this._authService.Login(model);
            return Ok(result);
        }

        [HttpPost("validateToken")]
        public bool ValidateToken(string token)
        {
            var result = this._tokenService.ValidateToken(token);
            return result;
        }
    }
}
