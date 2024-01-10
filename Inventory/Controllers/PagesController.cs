using Inventory.Core;
using Inventory.Models;
using Inventory.Services.IRepo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Inventory.Utility;
using Inventory.Utility.ERP.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventory.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        public readonly ILoginPage _page;
        //public readonly IEmailService _emailService;
        public PagesController(ILoginPage page /*, IEmailService emailSender*/)
        {
                _page = page;
            //_emailService = emailSender;
        }
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignIn(LoginViewModel login)
        {
            string result = string.Empty;
            LoginandRegistration getuser = new LoginandRegistration();
            if (ModelState.IsValid)
            {
                if (login != null)
                {
                    getuser = _page.Login(login);
                    if (getuser == null)
                    {
                        TempData["Credentials"] = "Invalid Credentials. Please re-enter Credentials";
                    }
                    else
                    {
                        var roleName= objRoleList[Convert.ToInt32( getuser.Designation)];
                        HttpContext.Session.SetString("UserName", getuser.FullName);
                        HttpContext.Session.SetString("userEmail", getuser.Email);
                        HttpContext.Session.SetString("userPassword", getuser.Password);
                        var claims = new[] {
                                        new Claim(ClaimTypes.Email, getuser.Email)
                        ,new Claim(ClaimTypes.Role, roleName)};

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            authProperties);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }


        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignUp(LoginandRegistration register)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                if (!_page.IsEmailExist(register.Email))
                {

                    result = _page.Registration(register);
                    if (result == "Success")
                    {
                        return RedirectToAction("SignIn");
                    }
                }
                else
                {
                    TempData["IsEmailexist"] = "Email is already exist";
                }
            }
            
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgetPassword(ForgetPassword forgetPassword)
        {
            if (ModelState.IsValid)
            {
                if (_page.IsEmailExist(forgetPassword.Email))
                {
                    Random random = new Random();
                    string passcode = random.Next(9999).ToString();

                    string subject = "Test Email";
                    string htmlMessage = "This is your passcode :" + passcode;
                    EmailSender emailsender = new EmailSender("", forgetPassword.Email, subject, htmlMessage);
                    if (emailsender.SendEmail())
                    {
                        TempData["Resetemail"] = forgetPassword.Email;
                        TempData["Passcode"] = passcode;
                        return RedirectToAction("VerifyPasscodePassword", "Pages");
                    }
                }
                else
                {
                    TempData["Emailexistresult"] = "Email does not exist";
                }
                
            }
            return View();
        }
        [AllowAnonymous]
        public JsonResult ResendPasscode(string EmailId)
        {
            if (_page.IsEmailExist(EmailId))
            {
                Random random = new Random();
                string passcode = random.Next(9999).ToString();

                string subject = "Test Email";
                string htmlMessage = "This is your passcode :" + passcode;
                EmailSender emailsender = new EmailSender("", EmailId, subject, htmlMessage);
                if (emailsender.SendEmail())
                {

                    TempData["Passcode"] = passcode;
                    TempData["ResendPasscode"] = "Passcode sent successfully";

                }
            }
            else
            {
                TempData["Emailexistresult"] = "Email does not exist";
            }
            return Json(new { Success = true });

        }
    

        [HttpGet]
        [AllowAnonymous]
        public IActionResult VerifyPasscodePassword()
        {
            VerifyPassword verifyPassword = new VerifyPassword();
            verifyPassword.Email = TempData["Resetemail"].ToString();
            return View(verifyPassword);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult VerifyPasscodePassword(VerifyPassword verify)
        {
            if (ModelState.IsValid)
            {
                ResetPassword resetPassword = new ResetPassword();
                resetPassword.Email = verify.Email;
                resetPassword.Password = verify.Password;
                resetPassword.ConfirmPassword = verify.ConfirmPassword;
                
                string result = _page.UpdatePassword(resetPassword);
                TempData["resetresult"] = result;
                return RedirectToAction("SignIn");
            }
            
            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            
            if (ModelState.IsValid)
            {
                resetPassword.Email = HttpContext.Session.GetString("userEmail");
                string result=_page.UpdatePassword(resetPassword);
                TempData["resetresult"]=result;
            }
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        
        public IActionResult Error500()
        {
            return View();
        }
        public IActionResult CountriesList()
        {
            return View();
        }
        public IActionResult StateList()
        {
            return View();
        }
        public IActionResult BlankPage()
        {
            return View();
        }
        public IActionResult Components()
        {
            return View();
        }

       public Dictionary<int, string> objRoleList = new Dictionary<int, string>(){

                                                                      {1, "Admin"},
                                                                      {2, "User"},
                                                                      {3, "Manager"},
                                                                    {4, "Supervisor"} 
       };
        
    }
}
