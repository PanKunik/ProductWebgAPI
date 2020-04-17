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
// TODO: Make documentation on GitHub
// TODO: Describe every project, every folder and every place
namespace PSMDataManagerMVC.Controllers
{
    public class ProductController : Controller
    {
        // TODO: Make one ViewModel for Products, Categories and Brands
        // GET: Product
        public async Task<ActionResult> Index()
        {
            ProductViewModel products = new ProductViewModel(new ProductEndpoint(new APIHelper()));

            await products.LoadProducts();

            return View(products);
        }

        public PartialViewResult _CategoriesPartial()
        {
            CategoriesViewModel cats = new CategoriesViewModel(new CategoryEndpoint(new APIHelper()));

            cats.LoadCategories();

            return PartialView(cats);
        }
    }
}
