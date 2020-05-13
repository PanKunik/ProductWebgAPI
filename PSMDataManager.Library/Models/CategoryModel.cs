using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        [MinLength(2, ErrorMessage = "Category name must have at least 2 signs.")]
        [MaxLength(64, ErrorMessage = "Category name must be shorter or equal 64 signs.")]
        [DataType(DataType.Text)]
        public string Category { get; set; }
    }
}
