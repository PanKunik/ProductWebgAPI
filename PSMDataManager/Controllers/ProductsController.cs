using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Models;
using Swashbuckle.Swagger;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PSMDataManager.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [HttpGet]
        [ResponseType(typeof(List<ProductDBModel>))]
        public HttpResponseMessage Get([FromUri]ProductFilter filter)
        {
            ProductData data = new ProductData();
            List<ProductDBModel> products = data.GetProducts(filter);

            HttpResponseMessage response;

            if(products.Count() <= 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values. " });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, products);
            }

            return response;
        }

        // GET: api/Products/id
        [HttpGet]
        [ResponseType(typeof(ProductDBModel))]
        public HttpResponseMessage GetById(int id)
        {
            ProductData data = new ProductData();
            ProductDBModel product = data.GetProductById(id);

            HttpResponseMessage response;

            if(product == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, product);
            }

            return response;
        }

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(ProductModel))]
        public HttpResponseMessage Post(ProductModel product)
        {
            ProductData data = new ProductData();
            HttpResponseMessage result;

            if(ModelState.IsValid)
            {
                ModelsValidation validation = new ModelsValidation();

                if(validation.DoesBrandExist(product.BrandId) == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no brand with this Id." });
                }

                if (validation.DoesCategoryExist(product.CategoryId) == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no category with this Id." });
                }

                data.SaveProduct(product);
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid model. Some values are null or out of range." });
            }

            return result;
        }

        // PUT: api/products/id
        [HttpPut]
        [ResponseType(typeof(ProductDBModel))]
        public void Put([System.Web.Mvc.Bind(Include = "Id")]int id, [System.Web.Mvc.Bind(Include = "Name, Description,CategoryId, BrandId" )] ProductModel product)
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
