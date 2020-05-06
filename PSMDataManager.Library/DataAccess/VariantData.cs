using PSMDataManager.Library.Internal.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.DataAccess
{
    public class VariantData
    {
        public List<VariantDBModel> GetVariantById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var variant = sql.LoadData<VariantDBModel, dynamic>("dbo.spVariantLookup", parameters, "DefaultConnection");

            return variant;
        }

        public List<VariantDBModel> GetVariants()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var variants = sql.LoadData<VariantDBModel, dynamic>("dbo.spVariantGetAll", new { }, "DefaultConnection");

            return variants;
        }

        public List<VariantModel> GetVariantsOfProduct(int productId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { ProductId = productId };

            var variants = sql.LoadData<VariantModel, dynamic>("dbo.spVariantLookupByProduct", parameters, "DefaultConnection");

            return variants;
        }

        public List<VariantModel> GetVariantsInPriceRange(int? minPrice, int? maxPrice)
        {
            SqlDataAccess sql = new SqlDataAccess();

            if(maxPrice == null)
            {
                maxPrice = int.MaxValue;
            }

            if(minPrice == null)
            {
                minPrice = 0;
            }
            
            var parameters = new { MinPrice = minPrice, MaxPrice = maxPrice };

            var variants = sql.LoadData<VariantModel, dynamic>("dbo.spVariantLookupByPrice", parameters, "DefaultConnection");

            return variants;
        }

        public void SaveVariant(VariantModel variant)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spVariantInsert", variant, "DefaultConnection");
        }

        public void UpdateVariant(int id, VariantModel variant)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id, ProductId = variant.ProductId, BasePrice = variant.BasePrice, Tax = variant.Tax, InStock = variant.InStock }; 

            sql.UpdateData("dbo.spVariantUpdateById", parameters, "DefaultConnection");
        }
    }
}
