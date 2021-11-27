using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

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
