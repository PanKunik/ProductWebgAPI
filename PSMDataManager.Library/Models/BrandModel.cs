using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Models
{
    public class BrandModel
    {
        [Required(ErrorMessage = "Brand name is required.")]
        [MinLength(2, ErrorMessage = "Brand name must have at least 2 signs.")]
        [MaxLength(64, ErrorMessage = "Brand name must be shorter or equal 64 signs.")]
        [DataType(DataType.Text)]
        public string Brand { get; set; }
    }
}
