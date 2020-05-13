using PSMDataManager.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSMDataManager
{
    internal class ModelsValidation
    {
        internal bool DoesCategoryExist(int id)
        {
            bool exist = true;

            CategoryData categoryData = new CategoryData();
            var data = categoryData.GetCategoryById(id);

            if(data == null)
            {
                exist = false;
            }

            return exist;
        }

        internal bool DoesBrandExist(int id)
        {
            bool exist = true;

            BrandData brandData = new BrandData();
            var data = brandData.GetBrandById(id);

            if(data == null)
            {
                exist = false;
            }

            return exist;
        }

        internal bool DoesProductExist(int id)
        {
            bool exist = true;

            ProductData productData = new ProductData();
            var data = productData.GetProductById(id);

            if(data == null)
            {
                exist = false;
            }

            return exist;
        }
    }
}