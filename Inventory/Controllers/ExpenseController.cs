using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Authorize(Roles ="User")]
    public class ExpenseController : Controller
    {
        public IActionResult ExpenseList()
        {
            return View();
        }
        public IActionResult ExpenseCategory()
        {
            return View();
        }
        
    }
}
