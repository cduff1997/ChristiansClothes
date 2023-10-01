using Microsoft.AspNetCore.Http;
using ChristiansClothes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChristiansClothes.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                return View(contactModel);
            }
            return View(contactModel);
        }
    }
}
