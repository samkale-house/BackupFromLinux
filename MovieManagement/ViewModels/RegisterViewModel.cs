using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MovieManagement.Validation;

namespace MovieManagement.ViewModels
{
    public class RegisterViewModel:GoogleReCaptchaModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirmation Password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}
