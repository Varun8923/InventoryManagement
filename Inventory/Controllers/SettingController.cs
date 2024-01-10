using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult GeneralSettings()
        {
            return View();
        }
        public IActionResult EmailSettings()
        {
            return View();
        }
        public IActionResult Paymentsettings()
        {
            return View();
        }
        public IActionResult CurrencySettings()
        {
            return View();
        }
        public IActionResult GroupPermissions()
        {
            return View();
        }
        public IActionResult TaxRates()
        {
            return View();
        }
       
    }
}
