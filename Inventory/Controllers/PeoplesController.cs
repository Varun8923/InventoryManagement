using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class PeoplesController : Controller
    {
        public IActionResult CustomerList()
        {
            return View();
        }
        public IActionResult SupplierList()
        {
            return View();
        }
        public IActionResult UserList()
        {
            return View();
        }
        public IActionResult StoreList()
        {
            return View();
        }
    }
}
