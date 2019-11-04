using Microsoft.AspNetCore.Mvc;
using System;


namespace Async_Inn.Controllers
{
    /// <summary>
    /// Summary description for HomeController
    /// </summary> 

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
