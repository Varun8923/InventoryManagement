using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Core
{
    public class VerifyPassword
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Passcode is Required.")]
        public string Passcode { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password shuld have at least One Upper case letter, one Lower case letter , one digit and special character are required ")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is Required.")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
