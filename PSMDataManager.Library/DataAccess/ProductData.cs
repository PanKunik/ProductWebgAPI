using PSMDataManager.Library.Filters;
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

        public List<ProductDBModel> GetProducts(ProductFilter filter)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { BrandId = filter.Brand, CategoryId = filter.Category, Name = filter.Name };

            var products = sql.LoadData<ProductDBModel, dynamic>("dbo.spProductGetAll", parameters, "DefaultConnection");

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

        public void DeleteProductById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id}; 

            sql.UpdateData<dynamic>("dbo.spProductDeleteById", parameters, "DefaultConnection");
        }
    }
}
