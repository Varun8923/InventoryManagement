using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult NewUser()
        {
            return View();
        }
        public IActionResult Newuseredit()
        {
            return View();
        }
        public IActionResult UserLists()
        {
            return View();
        }
    }
}
