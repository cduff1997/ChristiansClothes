using System.ComponentModel.DataAnnotations;

namespace ChristiansClothes.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(30, ErrorMessage = "First name must be 30 characters or less.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First name cannot contain special characters or numbers.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(30, ErrorMessage = "Last name must be 30 characters or less.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last name cannot contain special characters or numbers.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits and contain only numbers.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string? Message { get; set; }
    }
}