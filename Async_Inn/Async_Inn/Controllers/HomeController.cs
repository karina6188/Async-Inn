using Microsoft.AspNetCore.Mvc;
using System;

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
