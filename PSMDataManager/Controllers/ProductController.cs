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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }

        // GET: api/Product/5
        public ProductModel GetById(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductById(id).First();
        }

        // POST: api/Product

        public void Post(ProductModel product)
        {
            ProductData data = new ProductData();

            data.SaveProduct(product);
        }
    }
}
