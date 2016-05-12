using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OBSPRO.Models
{
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

}