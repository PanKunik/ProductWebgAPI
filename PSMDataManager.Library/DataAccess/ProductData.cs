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
        public List<ProductDBModel> GetProductById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var product = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductLookup", parameters, "DefaultConnection");

            return product;
        }

        public List<ProductDBModel> GetProductByCategory(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var product = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductLookupByCategory", parameters, "DefaultConnection");

            return product;
        }

        public List<ProductDBModel> GetProductByBrand(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var product = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductLookupByBrand", parameters, "DefaultConnection");

            return product;
        }

        public List<ProductDBModel> SearchProducts(string Keyword)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Keyword = Keyword };

            var product = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductLookupByName", parameters, "DefaultConnection");

            return product;
        }

        public List<ProductDBModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var products = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductGetAll", new { }, "DefaultConnection");

            return products;
        }

        public void SaveProduct(ProductModel product)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData<dynamic>("dbo.spProductInsert", product, "DefaultConnection");
        }

        public void UpdateProductById(int id, ProductModel product)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id, Name = product.Name, Description = product.Description, CategoryId = product.CategoryId, BrandId = product.BrandId }; 

            sql.UpdateData<dynamic>("dbo.spProductUpdateById", parameters, "DefaultConnection");
        }
    }
}
