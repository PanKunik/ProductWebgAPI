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
    }
}
