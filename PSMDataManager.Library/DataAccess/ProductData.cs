using PSMDataManager.Library.Internal.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProductById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var product = sql.LoadData<ProductModel, dynamic>("dbo.spProductLookup", parameters, "DefaultConnection");

            return product;
        }

        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var products = sql.LoadData<ProductModel, dynamic>("dbo.spProductGetAll", new { }, "DefaultConnection");

            return products;
        }

        public void SaveProduct(ProductModel product)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spProductInsert", product, "DefaultConnection");
        }
    }
}
