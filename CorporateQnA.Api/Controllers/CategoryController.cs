using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
