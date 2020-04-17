using PSMDataManager.Library.Internal.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.DataAccess
{
    public class CategoryData
    {
        public List<CategoryModel> GetCategories()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var categories = sql.LoadData<CategoryModel, dynamic>("dbo.spCategoryGetAll", new { }, "DefaultConnection");

            return categories;
        }
    }
}
