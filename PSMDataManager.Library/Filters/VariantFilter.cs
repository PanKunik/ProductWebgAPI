using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Filters
{
    public class VariantFilter
    {
        public int? Page { get; set; }
        public byte? Limit { get; set; }
        public int? Product { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
