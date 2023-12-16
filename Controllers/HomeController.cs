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
            ViewBag.IsHomePage = true;
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

        public IActionResult Events()
        {
            List<Event> events = GetEvents();
            return View(events);
        }

        private List<Event> GetEvents()
        {
            return new List<Event>
        {
            new Event
            {
                Title = "Grand Opening Sale",
                Description = "Join us for the grand opening sale with amazing discounts on all products.",
                AgeGroup = "All Ages",
                DateAndTime = new DateTime(2023, 12, 1, 10, 0, 0),
                Location = "123 Main Street, Cleveland",
                RegistrationInfo = "No registration required"
            },
            new Event
            {
                Title = "Fashion Show",
                Description = "Experience the latest fashion trends in our exclusive online fashion show.",
                AgeGroup = "Adults",
                DateAndTime = new DateTime(2023, 12, 10, 15, 30, 0),
                Location = "Online (Streaming on our website)",
                RegistrationInfo = "Register at christiansclothes.com/fashion-show"
            },
            new Event
            {
                Title = "Kids' Day Out",
                Description = "A fun-filled day for kids with games, activities, and special surprises.",
                AgeGroup = "Kids (5-12 years)",
                DateAndTime = new DateTime(2023, 12, 15, 13, 0, 0),
                Location = "Edgewater Park, Kids Zone",
                RegistrationInfo = "Register at christiansclothes.com/kids-day-out"
            },
            new Event
            {
                Title = "Exclusive Product Launch Party",
                Description = "Be the first to witness the launch of our newest product line! Join our online launch party featuring live demonstrations, product showcases, and special discounts for attendees.",
                AgeGroup = "Teens and Adults",
                DateAndTime = new DateTime(2023, 12, 20, 18, 0, 0),
                Location = "Online (Live event on our website)",
                RegistrationInfo = "Register at christiansclothes.com/launch-party"
            }
        };
        }
    }
}