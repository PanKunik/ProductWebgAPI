using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PSMDataManager.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }

        // GET: api/Products/5
        public ProductModel GetById(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductById(id).First();
        }
    }
}
