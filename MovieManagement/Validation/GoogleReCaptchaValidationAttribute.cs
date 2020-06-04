using Microsoft.Extensions.Configuration;  
using Newtonsoft.Json.Linq;  
using System;  
using System.ComponentModel.DataAnnotations;  
using System.Net;  
using System.Net.Http;  
/*There are few tricks I had to do in order to make the custom validation attribute work 
and to be easy to modify. First thing is using Lazy keyword for invalid validation result. 
Since there are multiple occasions where model is not valid, we would have to generate the 
same response multiple times which would cause code repetition, so I decided to use Lazy class 
to make the invalid response instance only in case it is really needed. For successful response, 
for example, invalid ValidationResult instance would never be initiated.

Second, more important trick is accessing the configuration injected instance from 
the ValidationAttribute class instance. Unlike Controllers, you cannot use parameterized constructor, 
so you need to take it from the ValidationContext

*/
  
namespace MovieManagement.Validation  
{  
  
    public class GoogleReCaptchaValidationAttribute : ValidationAttribute  
    {           
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)  
        {  
            Lazy<ValidationResult> errorResult = new Lazy<ValidationResult>(() => new ValidationResult("Google reCAPTCHA validation failed", new String[] { validationContext.MemberName }));  
  
            if (value == null || String.IsNullOrWhiteSpace( value.ToString()))   
            {  
                return errorResult.Value;  
            }  
  
            IConfiguration configuration = (IConfiguration)validationContext.GetService(typeof(IConfiguration));  
            String reCaptchResponse = value.ToString();  
            String reCaptchaSecret = configuration.GetValue<String>("GoogleReCaptcha:SecretKey");  
              
  
            HttpClient httpClient = new HttpClient();  
            var httpResponse = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={reCaptchaSecret}&response={reCaptchResponse}").Result;  
            if (httpResponse.StatusCode != HttpStatusCode.OK)  
            {  
                return errorResult.Value;  
            }  
  
            String jsonResponse = httpResponse.Content.ReadAsStringAsync().Result;  
            dynamic jsonData = JObject.Parse(jsonResponse);  
            if (jsonData.success != true.ToString().ToLower())  
            {  
                return errorResult.Value;  
            }  
  
            return ValidationResult.Success;  
        }
          
    }  
}  