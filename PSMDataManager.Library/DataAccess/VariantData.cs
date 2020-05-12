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
    public class VariantData
    {
        public VariantDBModel GetVariantById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = Id };

            var variant = sql.LoadData<VariantDBModel, dynamic>("dbo.spVariantLookup", parameters, "DefaultConnection");

            return variant.FirstOrDefault();
        }

        public List<VariantDBModel> GetVariants(VariantFilter filter)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { ProductId = filter.Product, MinPrice = filter.MinPrice, MaxPrice = filter.MaxPrice };

            var variants = sql.LoadData<VariantDBModel, dynamic>("dbo.spVariantGetAll", parameters, "DefaultConnection");

            return variants;
        }

        public void SaveVariant(VariantModel variant)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spVariantInsert", variant, "DefaultConnection");
        }

        public void UpdateVariantById(int id, VariantModel variant)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id, ProductId = variant.ProductId, BasePrice = variant.BasePrice, Tax = variant.Tax, InStock = variant.InStock }; 

            sql.UpdateData("dbo.spVariantUpdateById", parameters, "DefaultConnection");
        }

        public void DeleteVariantById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Id = id}; 

            sql.UpdateData("dbo.spVariantDeleteById", parameters, "DefaultConnection");
        }
    }
}
