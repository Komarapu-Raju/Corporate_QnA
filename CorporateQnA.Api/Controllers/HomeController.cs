﻿using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
