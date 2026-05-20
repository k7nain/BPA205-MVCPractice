using System.ComponentModel.DataAnnotations;

namespace Bilet_1_Practice_.ViewModels.Account
{
    public class LoginVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
