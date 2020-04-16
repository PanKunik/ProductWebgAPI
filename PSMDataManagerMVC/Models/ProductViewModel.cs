using PSMDataManagerMVC.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class ProductViewModel
    {
        private IProductEndpoint _productEndpoint;

        public List<ProductModel> products;

        public ProductViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;

        }
    }
}