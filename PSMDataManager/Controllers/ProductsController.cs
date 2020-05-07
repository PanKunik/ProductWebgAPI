using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PSMDataManager.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [HttpGet]
        public List<ProductDBModel> Get([FromUri]ProductFilter filter)
        {
            ProductData data = new ProductData();

            return data.GetProducts(filter);
        }

        // GET: api/Products/id
        [HttpGet]
        public ProductDBModel GetById(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductById(id).First();
        }

        // POST: api/Products
        [HttpPost]
        public void Post(ProductModel product)
        {
            ProductData data = new ProductData();

            data.SaveProduct(product);
        }

        // PUT: api/products/id
        [HttpPut]
        public void Put(int id, ProductModel product)
        {
            ProductData data = new ProductData();

            data.UpdateProductById(id, product);
        }

        // DELETE:
        [HttpDelete]
        public void Delete(int id)
        {
            ProductData data = new ProductData();

            data.DeleteProductById(id);
        }
    }
}
