using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace MovieManagement.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
          //  ExternalLoginSchemes= new List<AuthenticationScheme>();
        }
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLoginSchemes { get; set; }
    }
}
