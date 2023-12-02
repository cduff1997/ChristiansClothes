using System.ComponentModel.DataAnnotations;

namespace ChristiansClothes.Models
{

    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Product image is required.")]
        public string? ProductImage { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ProductPrice { get; set; }
    }
}