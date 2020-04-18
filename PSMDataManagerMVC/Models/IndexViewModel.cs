using PSMDataManagerMVC.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class IndexViewModel
    {
        public ProductViewModel Products;
        public BrandViewModel Brands;
        public CategoryViewModel Categories;

        public IndexViewModel()
        {
            APIHelper apiHelper = new APIHelper();

            Products = new ProductViewModel(new ProductEndpoint(apiHelper));
            Brands = new BrandViewModel(new BrandEndpoint(apiHelper));
            Categories = new CategoryViewModel(new CategoryEndpoint(apiHelper));
        }

        public async Task LoadData()
        {
            await Products.LoadProducts();
            await Brands.LoadBrands();
            await Categories.LoadCategories();
        }
    }
}