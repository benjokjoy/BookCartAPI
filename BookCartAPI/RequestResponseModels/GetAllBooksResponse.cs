using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace BookCartAPI.RequestResponseModels
{
    [ExcludeFromCodeCoverage]
    public class GetAllBooksResponse
    {
        public List<BooksResponse> BooksResponse { get; set; }
        public int TotalCount { get; set; }
    }
}
