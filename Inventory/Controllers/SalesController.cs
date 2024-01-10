using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult SalesList()
        {
            return View();
        }
        public IActionResult InvoiceReport()
        {
            return View();
        }
        public IActionResult SalesReturnList()
        {
            return View();
        }
        public IActionResult QuotationList()
        {
            return View();
        }
        public IActionResult Pos()
        {
            return View();
        }
        public IActionResult TransferList()
        {
            return View();
        }
        public IActionResult ImportTransfer()
        {
            return View();
        }
        public IActionResult PurchaseReturnList()
        {
            return View();
        }
    }
}
