using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Services
{
    public interface ITokenService
    {
        public string GenerateToken(IdentityUser user);
        public bool ValidateToken(string token);
    }
}
