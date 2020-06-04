using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MovieManagement.Models;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,ILogger<AccountController> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger=logger;
        }

[AllowAnonymous]
[HttpGet]
public IActionResult Register()
        {            
            return View();
        }

[AllowAnonymous]
[HttpPost]
public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
           //validate model
           //create user useriden
           //if passed signin 
           
           //add errormessage to modelstate if recaptcha fails
           if (!ModelState.IsValid)
{
string messages = string.Join("; ", ModelState.Values
.SelectMany(x => x.Errors)
.Select(x => x.ErrorMessage));
if (messages.ToLower().Contains("recaptcha"))
{
ModelState.Clear();
ModelState.AddModelError("", "Please check recaptcha");
}}
           
           if(ModelState.IsValid)
            {
                var newUser = new ApplicationUser() { UserName = registerVM.Email, Email = registerVM.Email };
                var existingUser =await _userManager.FindByNameAsync(registerVM.Email);//username already exists
                if(existingUser==null){
                var result = await _userManager.CreateAsync(newUser, registerVM.Password);
 
                if (result.Succeeded)
                {
                    var confirmEmailToken=await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //send token and userid in email confirmation link
                var confirmationLink = Url.Action("ConfirmEmail", "Account",
    new { userId = newUser.Id, token = confirmEmailToken }, Request.Scheme);//request.scheme means http or https for absoluteurl
    _logger.Log(LogLevel.Warning,"Please click on a link for emailconfirmation:   "+confirmationLink);
   // var message = new Message(new string[] { newUser.Email }, "Confirmation email link", confirmationLink, null);
    //await _emailSender.SendEmailAsync(message);

                    return RedirectToAction("RegistartionSuccess");
                   // await _signInManager.SignInAsync(newUser, isPersistent: false);
                   // return RedirectToAction("Index","home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                }
            }
            return View();
        }

[AllowAnonymous]
[HttpGet]
public IActionResult RegistartionSuccess()
{
return View();
}

[AllowAnonymous]
[HttpGet]
public async Task<IActionResult> ConfirmEmail(string token, string userId)
{
    var newlyAddedUser=await _userManager.FindByIdAsync(userId);
    var result = await _userManager.ConfirmEmailAsync(newlyAddedUser, token);
    if (result.Succeeded){
    return View("Login");}

    ViewBag.ErrorTitle = $"Confirmation link not valid";
        ViewBag.ErrorMessage = "please try to register again and do emailconfirmation.";

        
    return View("Error");
}
[AllowAnonymous]
[HttpGet]
public async Task<IActionResult> Login(string returnUrl)
        {_logger.LogWarning("in login now");
            LoginViewModel model=new LoginViewModel{
                ReturnUrl=returnUrl,
                ExternalLoginSchemes=
                (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()};
            return View(model);
        }        

[AllowAnonymous]
[HttpPost]
public async Task<IActionResult> Login(LoginViewModel loginVM,string returnurl)
        {
            //persistent cookie:if rembmerme is checked, identity cookie is persisted even if browser window closed and open again,user will be loggedin
            //Session cookieL if remember me is not selected,login cookie will be sent to server throught the server-client cmmunication to keep logged in throught session,but identity cookie
            //is lost when browser window closed and reopend ,user will be logged out.
            //returnurl present in Querystring,used to retrun to requested page after login
            if (ModelState.IsValid)
            {

                //chaccksif emailconfirmed,create claimprincipal and persist it via cookie,also locksout on failure.attempts.
                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, loginVM.RememberMe, false);        
                      



                if(result.Succeeded)   
                {
                    if(!string.IsNullOrEmpty(returnurl) && returnurl!="/" && Url.IsLocalUrl(returnurl))  //prevent open redirect attack chevk for local\external url
                    {
                        return Redirect(returnurl);
                        //return LocalRedirect(returnurl);
                    }
                    return RedirectToAction("Index", "home");
                }


                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
               
            }
            return View();
        }

[AllowAnonymous]
[HttpPost]
public IActionResult ExternalLogin(string provider,string returnUrl)
{ 
     //if sessionout and login again so redirectreturnurl needed
    var redirectUrl=Url.Action("ExternalLoginCallback","Account",new {returnUrl=returnUrl});
    var properties=_signInManager.ConfigureExternalAuthenticationProperties(provider,redirectUrl);
    return new ChallengeResult(provider,properties);        
 
}

[AllowAnonymous]
public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
{
    returnUrl = returnUrl ?? Url.Content("~/");

    LoginViewModel loginViewModel = new LoginViewModel
    {
        ReturnUrl = returnUrl,
        ExternalLoginSchemes =
                (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
    };

    if (remoteError != null)
    {
        ModelState
            .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

        return View("Login", loginViewModel);
    }

    // Get the login information about the user from the external login provider
    var info = await _signInManager.GetExternalLoginInfoAsync();
    if (info == null)
    {
        ModelState
            .AddModelError(string.Empty, "Error loading external login information.");

        return View("Login", loginViewModel);
    }

    // If the user already has a login (i.e if there is a record in AspNetUserLogins
    // table) then sign-in the user with this external login provider
    var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
        info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

    if (signInResult.Succeeded)
    {
        return LocalRedirect(returnUrl);
    }
    // If there is no record in AspNetUserLogins table, the user may not have
    // a local account
    else
    {
        // Get the email claim value
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);

        if (email != null)
        {
            // Create a new user without password if we do not have a user already
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                };

                await _userManager.CreateAsync(user);
            }

            // Add a login (i.e insert a row for the user in AspNetUserLogins table)
            await _userManager.AddLoginAsync(user, info);
            await _signInManager.SignInAsync(user, isPersistent: false);

            return LocalRedirect(returnUrl);
        }

        // If we cannot find the user email we cannot continue
        ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
        ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

        return View("Error");
    }
}

[HttpPost]
public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
