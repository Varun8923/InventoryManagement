using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult PurchaseList()
        {
            return View();
        }
        public IActionResult ImportPurchase()
        {
            return View();
        }
        public IActionResult PurchaseOrderReport()
        {
            return View();
        }
        public IActionResult PurchaseReturnList()
        {
            return View();
        }
    }
}
