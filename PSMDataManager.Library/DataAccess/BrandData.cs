using PSMDataManager.Library.Internal.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.DataAccess
{
    public class BrandData
    {
        public List<BrandModel> GetBrands()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var brands = sql.LoadData<BrandModel, dynamic>("dbo.spBrandGetAll", new { }, "DefaultConnection");

            return brands;
        }

        public BrandModel GetBrandById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id };

            var brand = sql.LoadData<BrandModel, dynamic>("dbo.spBrandLookup", parameters, "DefaultConnection");

            return brand.FirstOrDefault();
        }

        public void SaveBrand(string brand)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Brand = brand};

            sql.SaveData<dynamic>("dbo.spBrandInsert", parameters, "DefaultConnection");
        }

        public void UpdateBrandById(int id, string brand)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id, Brand = brand};

            sql.UpdateData<dynamic>("dbo.spBrandUpdateById", parameters, "DefaultConnection");
        }

        public void DeleteBrandById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id };

            sql.DeleteData<dynamic>("dbo.spBrandDeleteById", parameters, "DefaultConnection");
        }
    }
}
