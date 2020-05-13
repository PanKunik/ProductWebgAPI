using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Name of product is required.")]
        [MinLength(2, ErrorMessage = "Name of product must have at least 2 signs.")]
        [MaxLength(100, ErrorMessage = "Name of product must be shorter or equal 100 signs.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description of product is required.")]
        [DataType(DataType.MultilineText)]
        [MinLength(2)]
        public string Description { get; set; }
        [Required(ErrorMessage = "CategoryId is required.")]
        [Range(1,Int32.MaxValue, ErrorMessage = "CategoryId must be greater than 0.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "BrandId is required.")]
        [Range(1,Int32.MaxValue, ErrorMessage = "BrandId must be greater than 0.")]
        public int BrandId { get; set; }
    }
}
