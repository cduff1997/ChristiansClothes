using ChristiansClothes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace ChristiansClothes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplaySessionVariables()
        {
            HttpContext.Session.SetString("FirstName", "Christian");
            HttpContext.Session.SetString("LastName", "Duff");
            HttpContext.Session.SetString("Course", "IT2030");
            HttpContext.Session.SetInt32("FavNum", 23);

            return RedirectToAction("Tools");
        }

        public IActionResult ClearSessionVariables()
        {
            HttpContext.Session.Remove("FirstName");
            HttpContext.Session.Remove("LastName");
            HttpContext.Session.Remove("Course");
            HttpContext.Session.Remove("FavNum");

            return RedirectToAction("Tools");
        }

        public IActionResult Tools()
        {
            MySession model = new MySession
            {
                FirstName = HttpContext.Session.GetString("FirstName"),
                LastName = HttpContext.Session.GetString("LastName"),
                Course = HttpContext.Session.GetString("Course"),
                FavNum = HttpContext.Session.GetInt32("FavNum") ?? 0
            };

            return View(model);
        }
    }
}