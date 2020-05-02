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

        public CategoryModel GetCategoryById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id };

            var categories = sql.LoadData<CategoryModel, dynamic>("dbo.spCategoryLookup", parameters, "DefaultConnection");

            return categories.FirstOrDefault();
        }

        public void SaveCategory(string category)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Category = category };

            sql.SaveData<dynamic>("dbo.spCategoryInsert", parameters, "DefaultConnection");
        }

        public void UpdateCategoryById(int id, string category)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id, Category = category };

            sql.UpdateData<dynamic>("dbo.spCategoryUpdateById", parameters, "DefaultConnection");
        }

        public void DeleteCategoryById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id };

            sql.DeleteData<dynamic>("dbo.spCategoryDeleteById", parameters, "DefaultConnection");
        }
    }
}
