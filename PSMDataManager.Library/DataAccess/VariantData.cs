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
        public List<VariantModel> GetVariantById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            dynamic parameters = new { Id = Id };

            var variant = sql.LoadData<VariantModel, dynamic>("dbo.spVariantLookup", parameters, "DefaultConnection");

            return variant;
        }

        public List<VariantModel> GetVariants()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var variants = sql.LoadData<VariantModel, dynamic>("dbo.spVariantGetAll", new { }, "DefaultConnection");

            return variants;
        }

        public void SaveVariant(VariantModel variant)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.spVariantInsert", variant, "DefaultConnection");
        }
    }
}
