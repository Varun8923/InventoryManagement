using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult SalesReport()
        {
            return View();
        }
        public IActionResult PurchaseOrderReport()
        {
            return View();
        }
        public IActionResult InventoryReport()
        {
            return View();
        }
        public IActionResult InvoiceReport()
        {
            return View();
        }
        public IActionResult PurchaseReport()
        {
            return View();
        }
        public IActionResult SupplierReport()
        {
            return View();
        }
        public IActionResult CustomerReport()
        {
            return View();
        }
    }
}
