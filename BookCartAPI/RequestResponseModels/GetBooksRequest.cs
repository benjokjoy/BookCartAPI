using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.RequestResponseModels
{
    [ExcludeFromCodeCoverage]
    public class GetBooksRequest
    {
       
        public string TitleSearch { get; set; }
        
        [Required]
        public int PageNum { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
