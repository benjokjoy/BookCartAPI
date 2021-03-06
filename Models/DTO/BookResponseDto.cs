using System;

namespace Models.DTO
{
   public class BookResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public Decimal Price { get; set; }
    }
}
