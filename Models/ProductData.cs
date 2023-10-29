namespace ChristiansClothes.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public decimal? ProductPrice { get; set; }
    }

    public class ProductData
    {
        private static List<ProductModel> _products;

        static ProductData()
        {
            _products = new List<ProductModel>
            {
                new ProductModel { ProductId = 1, ProductName = "Men's Polo Shirt", ProductDescription = "Comfortable and Stylish Polo Shirt", ProductImage = "/images/MensPoloShirt.png", ProductPrice = 29.99M },
                new ProductModel { ProductId = 2, ProductName = "Women's Jeans", ProductDescription = "Classic Denim Jeans for Women", ProductImage = "/images/WomensJeans.png", ProductPrice = 39.99M },
                new ProductModel { ProductId = 3, ProductName = "Summer Dress", ProductDescription = "Light and Airy Summer Dress", ProductImage = "/images/SummerDress.png", ProductPrice = 49.99M },
                new ProductModel { ProductId = 4, ProductName = "Men's Shorts", ProductDescription = "Casual Men's Shorts for Everyday Wear", ProductImage = "/images/MensShorts.png", ProductPrice = 24.99M },
                new ProductModel { ProductId = 5, ProductName = "Women's Blouse", ProductDescription = "Elegant Blouse for Women", ProductImage = "/images/WomensBlouse.png", ProductPrice = 34.99M },
                new ProductModel { ProductId = 6, ProductName = "Kids' T-Shirt", ProductDescription = "Colorful T-Shirt for Kids", ProductImage = "/images/KidsTShirt.png", ProductPrice = 14.99M }
            };
        }

        public static List<ProductModel> GetProducts()
        {
            return _products;
        }

        public static ProductModel GetProduct(int id)
        {
            var product = _products.Find(p => p.ProductId == id);
            return product ?? new ProductModel();
        }
    }
}