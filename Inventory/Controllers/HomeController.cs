using Inventory.Core;
using Inventory.Models;
using Inventory.Services.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    [Authorize(Roles ="Admin")]
    
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginPage _page;

        public HomeController(ILogger<HomeController> logger, ILoginPage page)
        {
            _logger = logger;
            _page= page;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditStore()
        {
            return View();
        }
        
        public IActionResult Profile()
        {
            ProfileDataViewModel profiledata = new ProfileDataViewModel();
            string email = string.Empty;
            try
            {
                email = HttpContext.Session.GetString("userEmail");
                profiledata = _page.GetProfileData(email);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(profiledata);
        }
        [HttpPost]
        public IActionResult Profile(ProfileDataViewModel profiledata)
        {
            return View();
        }

        public IActionResult Activities()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
