using System.ComponentModel.DataAnnotations;

namespace Inventory.Core
{
    public class LoginandRegistration
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage ="Password shuld have at least One Upper case letter, one Lower case letter , one digit and special character are required ")]
        public string Password { get; set; }
        [Required]
        public string Designation { get; set; }
        


    }
}
