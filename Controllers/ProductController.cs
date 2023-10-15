using Microsoft.AspNetCore.Mvc;
using ChristiansClothes.Models;

namespace ChristiansClothes.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ListProducts()
        {
            var products = ProductData.GetProducts();

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = ProductData.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}