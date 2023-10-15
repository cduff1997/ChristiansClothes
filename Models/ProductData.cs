using System.Collections.Generic;

namespace ChristiansClothes.Models
{
    public class ProductData
    {
        private static List<ProductModel> _products;

        static ProductData()
        {
            _products = new List<ProductModel>
            {
                new ProductModel { ProductId = 1, ProductName = "Flute", ProductDescription = "Woodwind Instrument", ProductImage = "/images/Flute.png", ProductPrice = 19.99M },
                new ProductModel { ProductId = 2, ProductName = "Clarinet", ProductDescription = "Woodwind Instrument", ProductImage = "/images/Clarinet.png", ProductPrice = 29.99M },
                new ProductModel { ProductId = 3, ProductName = "Drums", ProductDescription = "Percussion Instrument", ProductImage = "/images/Drums.png", ProductPrice = 39.99M },
            };
        }

        public static List<ProductModel> GetProducts()
        {
            return _products;
        }

        public static ProductModel GetProduct(int id)
        {
            var product = _products.Find(p => p.ProductId == id);
            if (product == null)
            {
                return new ProductModel();
            }
            return product;
        }
    }
}
