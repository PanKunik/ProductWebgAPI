using PSMDataManagerMVC.Library.Api;
using PSMDataManagerMVC.Library.Models;
using PSMDataManagerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PSMDataManagerMVC.Controllers
{
    public class ProductController : Controller
    {

        IndexViewModel data;

        // GET: Product
        public async Task<ActionResult> Index()
        {
            data = new IndexViewModel();

            await data.LoadData();

            return View(data);
        }

        public PartialViewResult LoadProductsOfCategory(int categoryId)
        {
            data = new IndexViewModel();
            var result = Task.Run(() => data.Products.LoadProductByCategory(categoryId));
            result.Wait();

            return PartialView("_GeneralProductsPartial", data.Products);
        }

        public PartialViewResult LoadProductsOfBrand(int brandId)
        {
            data = new IndexViewModel();
            var result = Task.Run(() => data.Products.LoadProductByBrand(brandId));
            result.Wait();

            return PartialView("_GeneralProductsPartial", data.Products);
        }
    }
}
