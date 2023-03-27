using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
