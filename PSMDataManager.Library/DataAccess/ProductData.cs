using PSMDataManager.Library.Filters;
using PSMDataManager.Library.Internal.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public ProductDBModel GetProductById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = Id };

            string splitOnColumn = "VariantId";

            var productDictionary = new Dictionary<int, ProductDBModel>();

            Func<ProductDBModel, VariantDBModel, ProductDBModel> mappFunc = (product, variant) =>
            {
                ProductDBModel productEntry;

                if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                {
                    productEntry = product;
                    productEntry.Variants = new List<VariantDBModel>();
                    productDictionary.Add(productEntry.ProductId, productEntry);
                }

                if (variant != null)
                {
                    variant.Product_ProductId = product.ProductId;
                }

                productEntry.Variants.Add(variant);
                return productEntry;
            };

            var data = sql.LoadData<ProductDBModel, VariantDBModel, dynamic>("dbo.spProductLookup", mappFunc, splitOnColumn, parameters, "DefaultConnection");

            return data.FirstOrDefault();
        }

        public List<ProductDBModel> GetProducts(ProductFilter filter)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { BrandId = filter.Brand, CategoryId = filter.Category, Name = filter.Name };

            string splitOnColumn = "VariantId";

            var productDictionary = new Dictionary<int, ProductDBModel>();

            Func<ProductDBModel, VariantDBModel, ProductDBModel> mappFunc = (product, variant) =>
            {
                ProductDBModel productEntry;

                if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                {
                    productEntry = product;
                    productEntry.Variants = new List<VariantDBModel>();
                    productDictionary.Add(productEntry.ProductId, productEntry);
                }

                if (variant != null)
                {
                    variant.Product_ProductId = product.ProductId;
                }

                productEntry.Variants.Add(variant);
                return productEntry;
            };

            var products = sql.LoadData<ProductDBModel, VariantDBModel, dynamic>("dbo.spProductGetAll", mappFunc, splitOnColumn, null, "DefaultConnection");

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
