using CorporateQnA.DbContext;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CorporateQnA.Services
{
    public class TokenService : ITokenService
    {
        public readonly IConfiguration _configuration;

        public readonly IDbConnection _db;

        public TokenService(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            this._db = db.GetConnection();
        }

        public string GenerateToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var query = "Select id from employee where userId = @userId";
            var employeeId = this._db.QuerySingleOrDefault<Guid>(query,new { userId = user.Id });

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("activeUserId", employeeId.ToString())
            };

            var token = new JwtSecurityToken(notBefore: DateTime.Now,
                            expires: DateTime.Now.AddMinutes(1),
                            claims: claims,
                            signingCredentials: credentials
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
