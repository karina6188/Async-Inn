﻿using Microsoft.AspNetCore.Mvc;
using System;


namespace Async_Inn.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
