using PSMDataManagerMVC.Library.Api;
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
        public ProductViewModel products;

        // GET: Product
        public ActionResult Index()
        {
            APIHelper apiHelper = new APIHelper();
            ProductEndpoint productEndpoint = new ProductEndpoint(apiHelper);

            products.products = productEndpoint.GetAll();

            return View(products);
        }
    }
}
