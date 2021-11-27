using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.RequestResponseModels
{
    [ExcludeFromCodeCoverage]
    public class UpdateBookRequest
    {
        
        [Required]
        public long Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        [Range(0.0,(Double) decimal.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public Decimal ? Price { get; set; }
    }
}
