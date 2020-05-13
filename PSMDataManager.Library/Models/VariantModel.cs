using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Models
{
    public class VariantModel
    {
        [Required(ErrorMessage = "ProductId is required.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "ProductId must be greater tha 0.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "BasePrice value is required.")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Value of BasePrice must be greater or equal 0.")]
        public decimal BasePrice { get; set; }
        [Required(ErrorMessage = "Tax value is required.")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Value of Tax must be greater or equal 0.")]
        public decimal Tax { get; set; }
        [Required(ErrorMessage = "InStock number is required.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value of InStock must be greater or equal 0.")]
        public int InStock { get; set; }
    }
}
