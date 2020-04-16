using PSMDataManagerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSMDataManagerMVC.Controllers
{
    public class ProductController : Controller
    {
        public List<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Mąka Szymanowska typ 450",
                Description = "Dobra mąka! Jedz!",
                CategoryId = 1,
                BrandId = 1,
                VariantsCount = 3
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Mąka Babuni typ 650",
                Description = "Mąka bardzo, bardzo dobra do wypieków! Piecz!",
                CategoryId = 2,
                BrandId = 1,
                VariantsCount = 12
            },
        };

        // GET: Product
        public ActionResult Index()
        {
            return View(products);
        }
    }
}
