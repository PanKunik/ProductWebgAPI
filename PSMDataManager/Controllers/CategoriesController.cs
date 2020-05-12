using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace PSMDataManager.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        [HttpGet]
        [ResponseType(typeof(List<CategoryModel>))]
        public HttpResponseMessage Get()
        {
            CategoryData data = new CategoryData();
            List<CategoryModel> categories = data.GetCategories();

            HttpResponseMessage response;

            if(categories.Count() <= 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, categories);
            }

            return response;
        }

        // GET: api/Categories/id
        [HttpGet]
        [ResponseType(typeof(CategoryModel))]
        public HttpResponseMessage Get(int id)
        {
            CategoryData data = new CategoryData();
            CategoryModel category = data.GetCategoryById(id);

            HttpResponseMessage response;

            if(category == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No data found matching given parameters values." });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, category);
            }

            return response;
        }

        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody]string category)
        {
            CategoryData data = new CategoryData();

            data.SaveCategory(category);
        }

        // PUT: api/Categories/id
        [HttpPut]
        public void Put(int id, [FromBody]string category)
        {
            CategoryData data = new CategoryData();

            data.UpdateCategoryById(id, category);
        }

        // DELETE: api/Categories/id
        [HttpDelete]
        public void Delete(int id)
        {
            CategoryData data = new CategoryData();

            data.DeleteCategoryById(id);
        }
    }
}
