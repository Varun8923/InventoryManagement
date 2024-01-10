using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InvEntory.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        public IActionResult Editcategory()
        {
            return View();
        }
        public IActionResult Editcountry()
        {
            return View();
        }
        public IActionResult Editcustomer()
        {
            return View();
        }
        public IActionResult EditExpense()
        {
            return View();
        }
        public IActionResult Editpermission()
        {
            return View();
        }
        public IActionResult Editproduct()
        {
            return View();
        }
        public IActionResult Editpurchase()
        {
            return View();
        }
        public IActionResult Editpurchasereturn()
        {
            return View();
        }
        public IActionResult Editquotation()
        {
            return View();
        }
        public IActionResult Editsales()
        {
            return View();
        }
        public IActionResult Editsalesreturn()
        {
            return View();
        }
        public IActionResult Editsalesreturns()
        {
            return View();
        }
        public IActionResult Editstate()
        {
            return View();
        }
        public IActionResult Editstore()
        {
            return View();
        }
        public IActionResult Editsubcategory()
        {
            return View();
        }
        public IActionResult Editsupplier()
        {
            return View();
        }
        public IActionResult Edittransfer()
        {
            return View();
        }
        public IActionResult Edituser()
        {
            return View();
        }
        public IActionResult Editbrand()
        {
            return View();
        }
        public IActionResult Subaddcategory()
        {
            return View();
        }
    }
}
