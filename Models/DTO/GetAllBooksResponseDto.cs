using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
   public class GetAllBooksResponseDto
    {
        public List<BookResponseDto> BooksResponse { get; set; }
        public int TotalCount { get; set; }
    }
}
