using CorporateQnA.Core.Models;

namespace CorporateQnA.Services
{
    public interface IAuthService
    {
        public Task<response> Login(LoginModel model);

        public Task<string> Register(RegisterModel model);
    }
}
