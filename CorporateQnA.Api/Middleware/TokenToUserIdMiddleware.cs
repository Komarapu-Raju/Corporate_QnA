using CorporateQnA.Core.Models.UserContext;
using System.IdentityModel.Tokens.Jwt;

namespace CorporateQnA.Middleware
{
    public class TokenToUserIdMiddleware : IMiddleware
    {
        private UserContext _userContext;

        public TokenToUserIdMiddleware(UserContext userContext)
        {
            this._userContext = userContext;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].ToString();
            if (token != string.Empty)
            {
                token = token.Substring(7);
                var tokenHandler = new JwtSecurityTokenHandler();
                var employeeId = tokenHandler.ReadJwtToken(token).Claims.SingleOrDefault(c => c.Type == "activeUserId")?.Value;
                this._userContext.Id = Guid.Parse(employeeId);
            }
            return next(context);
        }
    }
}
