using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
   public class BookRequestDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public Decimal ? Price { get; set; }
    }
}
