using PSMDataManagerMVC.Library.Api;
using PSMDataManagerMVC.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class CategoriesViewModel
    {
        private ICategoryEndpoint _categoryEndpoint;

        private List<CategoryModel> _categories;

        public List<CategoryModel> Categories
        {
            get { return _categories;  }
            set { _categories = value; }
        }

        public CategoriesViewModel(ICategoryEndpoint categoryEndpoint)
        {
            _categoryEndpoint = categoryEndpoint;
        }

        public async Task LoadCategories()
        {
            var categories = await _categoryEndpoint.GetAll();
            Categories = new List<CategoryModel>(categories);
        }
    }
}