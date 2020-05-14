using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PSMDataManager.Controllers
{
    public class BrandsController : ApiController
    {
        // GET: /api/Brands
        [HttpGet]
        [ResponseType(typeof(List<BrandDBModel>))]
        public HttpResponseMessage Get()
        {
            BrandData data = new BrandData();
            List<BrandDBModel> brands = data.GetBrands();

            HttpResponseMessage response;

            if (brands.Count() <= 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, brands);
            }

            return response;
        }

        // GET: /api/Brands/id
        [HttpGet]
        [ResponseType(typeof(BrandDBModel))]
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Id parameter must be greater than 0." });
            }

            BrandData data = new BrandData();
            BrandDBModel brand = data.GetBrandById(id);

            HttpResponseMessage response;

            if (brand == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given id." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, brand);
            }

            return response;
        }

        // POST: api/Brands
        [HttpPost]
        [ResponseType(typeof(BrandModel))]
        public HttpResponseMessage Post([FromBody]BrandModel Brand)
        {
            HttpResponseMessage response;
            BrandData data = new BrandData();

            if(ModelState.IsValid)
            {
                data.SaveBrand(Brand.Brand);
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Brand name must be between 2 - 64 signs. Cannot be null or empty." });
            }

            return response;
        }

        // PUT: api/Brands/id
        [HttpPut]
        [ResponseType(typeof(BrandDBModel))]
        public HttpResponseMessage Put(int id, [FromBody][System.Web.Mvc.Bind(Include = "Brand")]BrandModel Brand)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            BrandData data = new BrandData();

            if(ModelState.IsValid)
            {
                if (validation.DoesBrandExist(id) == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no brand with given Id parameter." });
                }
                else
                {
                    data.UpdateBrandById(id, Brand.Brand);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Brand name must be between 2 - 64 signs. Cannot be null or empty." });
            }

            return response;
        }

        // DELETE: api/Brands/id
        [HttpDelete]
        [ResponseType(typeof(int))]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            BrandData data = new BrandData();

            if(validation.DoesBrandExist(id) == false)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no brand with given Id parameter." });
            }
            else
            {
                try
                {
                    data.DeleteBrandById(id);
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
        private HttpResponseMessage CheckSqlExceptionNumber(int number)
        {
            HttpResponseMessage response;

            switch (number)
            {
                case 547:
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Cannot delete this category. There are references to this row in other tables." });
                    break;
                default:
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Something went wrong. Contact with support or try again later." });
                    break;
            }

            return response;
        }
    }
}
