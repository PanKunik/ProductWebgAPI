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
        public List<string> categories = new List<string>();
        // GET: Product
        public async Task<ActionResult> Index()
        {
            ProductViewModel products = new ProductViewModel(new ProductEndpoint(new APIHelper()));

            await products.LoadProducts();

            return View(products);
        }
    }
}
