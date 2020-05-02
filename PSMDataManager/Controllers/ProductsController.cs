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
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [HttpGet]
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }

        // GET: api/Products/id
        [HttpGet]
        public ProductModel GetById(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductById(id).First();
        }

        // GET: api/Products/categoryId/id
        [HttpGet]
        [Route("api/Products/category/{id}")]
        public List<ProductModel> GetByCategoryId(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductByCategory(id);
        }

        // GET: api/Products/categoryId/id
        [HttpGet]
        [Route("api/Products/brand/{id}")]
        public List<ProductModel> GetByBrandId(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductByBrand(id);
        }

        // GET: api/Products/search/name
        [HttpGet]
        [Route("api/Products/search/{name}")]
        public List<ProductModel> SearchForProducts(string keyword)
        {
            ProductData data = new ProductData();

            return data.SearchProducts(keyword);
        }

        // POST: api/Products
        [HttpPost]
        public void Post(ProductModel product)
        {
            ProductData data = new ProductData();

            data.SaveProduct(product);
        }
    }
}
