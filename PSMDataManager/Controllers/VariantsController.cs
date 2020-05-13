using Microsoft.Ajax.Utilities;
using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

// TODO: Validate every given Id (range)
// TODO: Product - return Variants and features too
// TODO: Instead returning NoContent return Created at POST methods
// TODO: Refactor SqlException?
// TODO: Refactor checking if rows in other tables exist?

namespace PSMDataManager.Controllers
{
    public class VariantsController : ApiController
    {
        // GET: api/Variants
        [HttpGet]
        [ResponseType(typeof(List<VariantDBModel>))]
        public HttpResponseMessage Get([FromUri]VariantFilter filter)
        {
            VariantData data = new VariantData();
            List<VariantDBModel> variants = data.GetVariants(filter);

            HttpResponseMessage response;

            if (variants.Count() <= 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, variants);
            }

            return response;
        }

        // GET: api/Variants/id
        [HttpGet]
        [ResponseType(typeof(VariantDBModel))]
        public HttpResponseMessage Get(int id)
        {
            if(id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Id parameter must be greater than 0." });
            }

            VariantData data = new VariantData();
            VariantDBModel variant = data.GetVariantById(id);

            HttpResponseMessage response;

            if (variant == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, variant);
            }

            return response;
        }

        // POST: api/Variants
        [HttpPost]
        [ResponseType(typeof(VariantModel))]
        public HttpResponseMessage Post(VariantModel variant)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            VariantData data = new VariantData();

            if(ModelState.IsValid)
            {
                if(validation.DoesProductExist(variant.ProductId) == true)
                {
                    data.SaveVariant(variant);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no product with given Id parameter." });
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Product's id must be greater than 0. BasePrice, Tax and InStock must be a positive numbers." });
            }

            return response;
        }

        // PUT: api/Variants/id
        [HttpPut]
        [ResponseType(typeof(VariantDBModel))]
        public HttpResponseMessage Put(int id, [FromBody][System.Web.Mvc.Bind(Include = "ProductId, BasePrice, Tax, InStock")]VariantModel variant)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            VariantData data = new VariantData();

            if(ModelState.IsValid)
            {
                if(validation.DoesVariantExist(id) == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no variant with given Id parameter." });
                }
                else
                {
                    if(validation.DoesProductExist(variant.ProductId) == false)
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no product with given Id parameter." });
                    }
                    else
                    {
                        data.UpdateVariantById(id, variant);
                        response = Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Product's id must be greater than 0. BasePrice, Tax and InStock must be a positive numbers." });
            }

            return response;
        }

        // DELETE: api/Variants/id
        [HttpDelete]
        [ResponseType(typeof(int))]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            VariantData data = new VariantData();

            if(validation.DoesVariantExist(id) == false)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no variant with given Id parameter." });
            }
            else
            {
                try
                {
                    data.DeleteVariantById(id);
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
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Cannot delete this variant. There are references to this row in other tables." });
                    break;
                default:
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Something went wrong. Contact with support or try again later." });
                    break;
            }

            return response;
        }
    }
}
