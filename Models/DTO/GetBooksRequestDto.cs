

namespace Models.DTO
{
   public class GetBooksRequestDto
    {
        public string TitleSearch { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
