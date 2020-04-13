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

            var products = sql.LoadData<ProductModel, dynamic>("dbo.spProductLookup", parameters, "DefaultConnection");

            return products;
        }
    }
}
