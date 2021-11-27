using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.RequestResponseModels
{
    [ExcludeFromCodeCoverage]
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public string CoverImage { get; set; }
        [Required]
        [Range(0.0, (Double)decimal.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public Decimal Price { get; set; }
    }
}
