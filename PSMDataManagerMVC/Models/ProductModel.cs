using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int VariantsCount { get; set; }
    }
}