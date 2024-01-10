using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        public IActionResult Calender()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Email()
        {
            return View();
        }
    }
}
