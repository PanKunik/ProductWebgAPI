using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Models;
using Swashbuckle.Swagger;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            HttpResponseMessage response;
            ProductData data = new ProductData();

            if(ModelState.IsValid)
            {
                response = CanAddProduct(product.CategoryId, product.BrandId);

                if(response.StatusCode == HttpStatusCode.NoContent)
                {
                    data.SaveProduct(product);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid model. Some values are null or out of range." });
            }

            return response;
        }

        // PUT: api/products/id
        [HttpPut]
        [ResponseType(typeof(ProductDBModel))]
        public HttpResponseMessage Put([System.Web.Mvc.Bind(Include = "Id")]int id, [System.Web.Mvc.Bind(Include = "Name, Description,CategoryId, BrandId" )] ProductModel product)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            ProductData data = new ProductData();

            if(ModelState.IsValid)
            {
                if(validation.DoesProductExist(id) == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no product with given Id parameter." });
                }
                else
                {
                    data.UpdateProductById(id, product);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Name must be between 2 - 100 signs. Category and brand id must be greater than 0." });
            }

            return response;
        }

        // DELETE:
        [HttpDelete]
        [ResponseType(typeof(int))]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            ProductData data = new ProductData();

            if(validation.DoesProductExist(id) == false)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no product with given Id parameter." });
            }
            else
            {
                try
                {
                    data.DeleteProductById(id);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (SqlException sqlException)
                {
                    response = CheckSqlExceptionNumber(sqlException.Number);
                }
            }

            return response;
        }

        [NonAction]
        private HttpResponseMessage CanAddProduct(int category, int brand)
        {
            HttpResponseMessage response;

            ModelsValidation validation = new ModelsValidation();

            int result = 0;

            if(validation.DoesBrandExist(brand) == false)
            {
                result += 2;
            }

            if(validation.DoesCategoryExist(category) == false)
            {
                result += 1;
            }

            switch (result)
            {
                case 0:
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                    break;
                case 1:
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no category with given Id parameter." });
                    break;
                case 2:
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no brand with given Id parameter." });
                    break;
                default:
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There are no category and brand with given Id parameters." });
                    break;
            }

            return response;
        }

        [NonAction]
        private HttpResponseMessage CheckSqlExceptionNumber(int number)
        {
            HttpResponseMessage response;

            switch (number)
            {
                case 547:
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Cannot delete this product. There are references to this row in other tables." });
                    break;
                default:
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Something went wrong. Contact with support or try again later." });
                    break;
            }

            return response;
        }
    }
}
