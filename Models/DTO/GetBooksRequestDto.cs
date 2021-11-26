using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
   public class GetBooksRequestDto
    {
        public string TitleSearch { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
