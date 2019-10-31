using Microsoft.AspNetCore.Mvc;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class HomeController : Controller
{
	public IActionResult Index()
	{
        return View();
	}
}
