using Microsoft.Ajax.Utilities;
using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

// TODO: Validate model
// TODO: StatusCode return in actions
// TODO: Refactor SqlExceton?
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
        public void Post(VariantModel variant)
        {
            VariantData data = new VariantData();

            data.SaveVariant(variant);
        }

        // PUT: api/Variants/id
        [HttpPut]
        public void Put(int id, [FromBody]VariantModel variant)
        {
            VariantData data = new VariantData();

            data.UpdateVariantById(id, variant);
        }

        // DELETE: api/Variants/id
        [HttpDelete]
        public void Delete(int id)
        {
            VariantData data = new VariantData();

            data.DeleteVariantById(id);
        }
    }
}
