using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Filters
{
    public class ProductFilter
    {
        public int? Page { get; set; }
        public byte? Limit { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
