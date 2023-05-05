using CorporateQnA.Core.Models;

namespace CorporateQnA.Services
{
    public interface IAuthService
    {
        public Task<response> Login(LoginModel model);

        public Task<response> Register(RegisterModel model);
    }
}
