using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace PSMDataManager.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        [HttpGet]
        public List<CategoryModel> Get()
        {
            CategoryData data = new CategoryData();

            return data.GetCategories();
        }

        // GET: api/Categories/id
        [HttpGet]
        public CategoryModel Get(int id)
        {
            CategoryData data = new CategoryData();

            return data.GetCategoryById(id);
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
