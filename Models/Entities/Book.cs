using System;

namespace Models.Entities
{
   public class Book: BaseEntity
    {     
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public Decimal Price { get; set; }
    }
}
