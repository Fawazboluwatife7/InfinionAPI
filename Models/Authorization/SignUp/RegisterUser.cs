using System.ComponentModel.DataAnnotations;

namespace InfinionAPI.Models.Authorization.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "First is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
