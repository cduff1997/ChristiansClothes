using System.ComponentModel.DataAnnotations;

namespace ChristiansClothes.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message.")]
        public string Message { get; set; }
    }
}