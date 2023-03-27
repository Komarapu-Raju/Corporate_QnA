using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
