using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult Addbrand()
        {
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult AddSubCategory()
        {
            return View();
        }
        public IActionResult CategoryList()
        {
            return View();
        }
        public IActionResult BrandList()
        {
            return View();
        }
        public IActionResult SubCategoryList()
        {
            return View();
        }
        public IActionResult Barcode()
        {
            return View();
        }
        public IActionResult ImportProduct()
        {
            return View();
        }
    }
}
