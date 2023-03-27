using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
