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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Products/5
        public List<ProductModel> GetById(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductById(id);
        }
    }
}
