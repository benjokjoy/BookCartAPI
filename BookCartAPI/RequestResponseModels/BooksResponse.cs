using System;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.RequestResponseModels
{
    [ExcludeFromCodeCoverage]
    public class BooksResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public Decimal Price { get; set; }
    }
}
