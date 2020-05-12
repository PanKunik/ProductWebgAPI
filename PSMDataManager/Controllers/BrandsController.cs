using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
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
        [ResponseType(typeof(List<BrandModel>))]
        public HttpResponseMessage Get()
        {
            BrandData data = new BrandData();
            List<BrandModel> brands = data.GetBrands();

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
        [ResponseType(typeof(BrandModel))]
        public HttpResponseMessage Get(int id)
        {
            BrandData data = new BrandData();
            BrandModel brand = data.GetBrandById(id);

            HttpResponseMessage response;

            if (brand == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, brand);
            }

            return response;
        }

        // POST: api/Brands
        [HttpPost]
        public IHttpActionResult Post([FromBody]string brand)
        {
            HttpResponseMessage result;

            BrandData data = new BrandData();

            if (brand == "" || brand == null)
            {
                result = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "" });
            }
            else
            {
                data.SaveBrand(brand);
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return (IHttpActionResult)result;
        }

        // PUT: api/Brands/id
        [HttpPut]
        public void Put(int id, [FromBody]string brand)
        {
            BrandData data = new BrandData();

            data.UpdateBrandById(id, brand);
        }

        // DELETE: api/Brands/id
        [HttpDelete]
        public void Delete(int id)
        {
            BrandData data = new BrandData();

            data.DeleteBrandById(id);
        }
    }
}
