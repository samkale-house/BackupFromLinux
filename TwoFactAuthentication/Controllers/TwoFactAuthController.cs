using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TwoFactAuthentication.Models;
using Twilio.AspNet.Core;
//using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net.Mail;

//inastall twilio library and include below namespaces

namespace TwoFactAuthentication.Controllers
{
    public class TwoFactAuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public TwoFactAuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //on click of Generate OTP,call SendOTP,OTP will be sent
//https://www.youtube.com/watch?v=xO7xUVqBEiw
        
        [HttpGet]
        public IActionResult SendOTP()
        {
            TwoFactModel model=new TwoFactModel();
            model.receipientnumber="+13194997346";
            model.messagetobesent="Hello hubby, this is from my c# program.";
            return View(model);
        }
        [HttpPost]
        public IActionResult SendOTP(TwoFactModel model)
        {
            try{
                TempData["CurrentOTP"]=SendOTPhelper(model.receipientnumber,model.messagetobesent);
                return RedirectToAction("VerifyOTP");
                  

                }
            catch{
            ViewBag.otpsuccessmsg="OTP sent, if not received try again.";
            //add error to modelstste
            return View();}
        }

        public int SendOTPhelper(string recipientNumber,string messagebody)
        {
            
            int otpValue = new Random().Next(100000, 999999);            
            string TwilioAccountSid="AC221d2da9b22726fc518e34ae50b41b5f";
            string TwilioAuth="362cd71611a4148adfad53cbcfcec040";
            string TwilioNumber="+12182755700";
           recipientNumber="+13194997346";
            messagebody="Your OTP is "+otpValue+" sent by:sams project";

            try{
            TwilioClient.Init(TwilioAccountSid,TwilioAuth);
            var msgresult= MessageResource.Create(
            to:new PhoneNumber(recipientNumber),
            from:new PhoneNumber(TwilioNumber),
            body:messagebody            );
                     return otpValue;
            }

            catch (Exception e)
            {

                throw (e);
              
            }
        }

        [HttpGet]
        public ActionResult VerifyOTP()
        {
            return View();
        }
        //call verifyotp on verify button click
        [HttpPost]
        public ActionResult VerifyOTP(VerifyOTPvm model)
        {
            if(model.inputotp==Convert.ToInt32( TempData["CurrentOTP"]))
            {
                //login the user using identity classes 
                ViewBag.message="Otp Matched";
                // redirect to home
                        return RedirectToAction("Index","Home");
            }
            
            //add errmessage to LoginAction Summary
            return View("SendOTP");
            
            }

[HttpGet]
public ActionResult SendEmail(){return View();}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> SendEmail(int a)
{
            if (ModelState.IsValid)
    {
        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        var message = new MailMessage();
        message.To.Add(new MailAddress("sanvedanakale@gmail.com"));  // replace with valid value 
        message.From = new MailAddress("recipient@outlook.com");  // replace with valid value
        message.Subject = "ProjStudysubject";
        message.Body = string.Format(body, "Sanvedana_testprj", "sanvedanakale@gmail.com", "Message from my C3 prj.");
        message.IsBodyHtml = true;

        using (var smtp = new SmtpClient())
        {
            var credential = new NetworkCredential
            {
                UserName = "sanvedanakale@gmail.com",  // replace with valid value
                Password = "aainirmalakale"  // replace with valid value
            };
            smtp.Credentials = credential;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;


            await smtp.SendMailAsync(message);
            ViewBag.otpsuccessmsg="email sent";
            return RedirectToAction("VerifyOTP");
        }
    }
    return View();
        }
    }
    }

/*
//to get authenticationheader and retrieve username password from it,get authentication header from httpcontxt's request
//and decode from basic64 format and retrieve
var authHeader=HttpContext.Request.Header["Authorization"]; //authheader="Basic AdfgfSGHXZDBBBBdfdgfgghhhhh"
if(!string.isNullorEmpty(authHeader))
{
    var credentials=ASCIIEncoding.ASCII.GetString(
        Convert.FromBase64String(authHeader.Replace("Basic"," "))).split(':');
        var username=credentials[0];
        var pswd=credentials[1];
    
}
/*
what is Identity data: Identification?password,useri +  personal info:gender/city  +  What you are? patient/doctor
Identity data can be used for multiple applications.
Roles: Identity role or permission role. Roles can be treated as groups.
What are these terms: Authentication is handled by authentication middleware such as cookie or opeind connect. 
Asp.net core identity verify credentials,it is user store. Identity server offers protocol support for opeind connect.

ASP .Net Identity Structure:
 1. Stores (IUserStore.IRoleStore) : Storage.This is data access layer.It will allow you to cahnge database provider(sql to mysql,to nosql,sql to oracle) any time,
 which does not require any change throught application,as mapping part will be taken care by stores.
 2. Managers (UserManager,RoleManager) : This is where business logic leaves e.g.Verifying user by password,hashing password,managing roles
 3. Extensions (SignInManager,SecurityStampValidator)  :It further absracts Manager layer.e.g. SignInManager issues cookier based on user manager validates user.
 4.Entities: User, Role . These are the classes we use mostly.It's instance is the realtime user.
 applicationuser->SignInManager->UserManager->Stores->Database Server(Identity data resides here)

 It comes in 4 different dlls
 Microsoft.Extension.Identity.Core(password hashing ,token generation) & Microsoft.Extensions.Identity.Stores (userstore,rolestore adds data to identity data store) 
 Microsoft.AspNetCore.Identity(UserManager,RoleManager) & Microsoft.AspNetCore.Identity.EntityFrameworkCore(for identity dbcontext)
 
 .Net Identity comes with default options set for ,password strength or emailid constraints. This default settings can be changed by 
 IdentityOptions.**Check for UserManager class and RoleManager in microsoft
  
  IUserStore: 
  Every store have create update delete functions.Evrytime record in a store accessed by normalized form for consistency.
  e.g.If searhing by username,dbstore will look for normalized username SANKALE 
  Userstore also does work for entity rather than on property. 
  e.g.It can find users id if Userobject is passed(FindByIdAsync(user,token))
  There are other 13 stores(IUserPasswordStore,IUserEmailStore,IUserLockoutStore,IUserRoleStore,IQueryableUserStore(allows usermanager to have right access to data store.)etc.)

  1.Register user
  2.create custom store
  3.use dll and register user
We need: Microsoft.AspNetCore,Microsoft.AspNetCore.Mvc,Microsoft.AspNetCore.StaticFiles ,entity framework, visual studio, install .netcore identity packages manually.
go to proj startup>1.register the useridentity: services.AddIdentityCore<string>(option=>....)  

We are creating custom store,
public class AppUserStore:IUserStore<AppUser>
{
    //Implement IUserStore
}

*/
