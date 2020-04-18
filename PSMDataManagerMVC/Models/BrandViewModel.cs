using PSMDataManagerMVC.Library.Api;
using PSMDataManagerMVC.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class BrandViewModel
    {
        private IBrandEndpoint _brandEndpoint;

        private List<BrandModel> _brands;

        public List<BrandModel> Brands
        {
            get { return _brands; }
            set { _brands = value; }
        }

        public BrandViewModel(IBrandEndpoint brandsEndpoint)
        {
            _brandEndpoint = brandsEndpoint;
        }

        public async Task LoadBrands()
        {
            var brands = await _brandEndpoint.GetAll();
            Brands = new List<BrandModel>(brands);
        }
    }
}