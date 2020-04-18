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

        [Route("api/Product/categoryId/{id}")]
        // GET: api/Product/categoryId/id
        public List<ProductModel> GetByCategoryId(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductByCategory(id);
        }

        [Route("api/Product/brandId/{id}")]
        // GET: api/Product/categoryId/id
        public List<ProductModel> GetByBrandId(int id)
        {
            ProductData data = new ProductData();

            return data.GetProductByBrand(id);
        }

        // POST: api/Product
        public void Post(ProductModel product)
        {
            ProductData data = new ProductData();

            data.SaveProduct(product);
        }
    }
}
