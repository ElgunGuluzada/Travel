using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Travel.Entities;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}