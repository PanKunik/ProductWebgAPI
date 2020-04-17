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
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public List<CategoryModel> Get()
        {
            CategoryData data = new CategoryData();

            return data.GetCategories();
        }
    }
}
