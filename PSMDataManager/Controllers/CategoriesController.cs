using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [ResponseType(typeof(List<CategoryDBModel>))]
        public HttpResponseMessage Get()
        {
            CategoryData data = new CategoryData();
            List<CategoryDBModel> categories = data.GetCategories();

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
        [ResponseType(typeof(CategoryDBModel))]
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Id parameter must be greater than 0." });
            }

            CategoryData data = new CategoryData();
            CategoryDBModel category = data.GetCategoryById(id);

            HttpResponseMessage response;

            if (category == null)
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
        [ResponseType(typeof(CategoryModel))]
        public HttpResponseMessage Post([FromBody]CategoryModel Category)
        {
            HttpResponseMessage response;
            CategoryData data = new CategoryData();

            if (ModelState.IsValid)
            {
                data.SaveCategory(Category.Category);
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Category name must be between 2 - 64 signs. Cannot be null or empty." });
            }

            return response;
        }

        // PUT: api/Categories/id
        [HttpPut]
        [ResponseType(typeof(CategoryDBModel))]
        public HttpResponseMessage Put(int id, [FromBody][System.Web.Mvc.Bind(Include = "Category")]CategoryModel Category)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            CategoryData data = new CategoryData();

            if (ModelState.IsValid)
            {
                if (validation.DoesCategoryExist(id) == false)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no category with given Id parameter." });
                }
                else
                {
                    data.UpdateCategoryById(id, Category.Category);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Model is invalid.", ModelValidation = "Category name must be between 2 - 64 signs. Cannot be null or empty." });
            }

            return response;
        }

        // DELETE: api/Categories/id
        [HttpDelete]
        [ResponseType(typeof(int))]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            ModelsValidation validation = new ModelsValidation();
            CategoryData data = new CategoryData();

            if(validation.DoesCategoryExist(id) == false)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "There is no category with given Id parameter." });
            }
            else
            {
                try
                {
                    data.DeleteCategoryById(id);
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch(SqlException sqlException)
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
