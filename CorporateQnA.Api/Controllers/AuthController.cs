using CorporateQnA.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("authorization/")]
    public class AuthController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;

        public readonly IConfiguration _configuration;
        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return BadRequest("User with emailId already exists");
            }
            var newUser = new IdentityUser() { Email = model.Email, UserName = model.Email };
            var result = await this._userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                return Ok(this.GenerateToken(newUser));
            }
            return BadRequest("Registration failed");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User doesn't exists");
            }
            var checkPassword = await this._userManager.CheckPasswordAsync(user, model.Password);
            if (!checkPassword)
            {
                return BadRequest("Credentials doesn't match");
            }

            return Ok(this.GenerateToken(user));
        }

        [NonAction]
        public string GenerateToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(notBefore: DateTime.UtcNow,
                            expires: DateTime.UtcNow.AddMinutes(20),
                            claims: claims,
                            signingCredentials: credentials
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
