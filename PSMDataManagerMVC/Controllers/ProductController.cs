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

        static IndexViewModel data;

        public ProductController()
        {
            if (data == null)
                data = new IndexViewModel();
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            return View(data);
        }

        public async Task<RedirectToRouteResult> _LoadProducts()
        {
            await data.Products.LoadProducts();

            return RedirectToAction("Index");
        }

        public PartialViewResult _CategoriesPartial()
        {
            return PartialView();
        }
    }
}
