using Microsoft.AspNetCore.Mvc;  
using System;  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManagement.Validation  
{  
    public abstract class GoogleReCaptchaModelBase  
    {  
        /*
        Once we get response on the client side from the Google validation server, 
        we will have the hidden feild HTML Element named g-recaptcha-response added to the FORM tag 
        of out document DOM. Since you cannot have the property of this name in your model, 
        I used BindProperty attribute to bind this field to meaningful property called GoogleReCaptchaResponse. 
        */
        [Required]  
        [GoogleReCaptchaValidation]  
        [NotMapped]//excludes this from mapping to DB-so that database migrations will ignore this from model
        [BindProperty(Name = "g-recaptcha-response")]  
        public String GoogleReCaptchaResponse { get; set; }  
    }  
}  