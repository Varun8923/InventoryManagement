using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Core
{
    public class ForgetPassword
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
    }
}
