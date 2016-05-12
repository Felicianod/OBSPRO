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
     
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string email { get; set; }

        [Display(Name = "Employee ID")]
        public string emp_id { get; set; }
    }

}