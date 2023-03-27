using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
