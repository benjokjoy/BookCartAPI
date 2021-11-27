using Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBusiness.Book
{
    public interface IBookService
    {
        Task<GetAllBooksResponseDto> GetAllBooks(GetBooksRequestDto request);
        Task<BookResponseDto> GetBook(long id);
        Task<BookResponseDto> UpdatePrice(long id, decimal price);
        Task<BookResponseDto> UpdateBook(BookRequestDto request);
        Task<BookResponseDto> CreateBook(BookRequestDto request);
        Task<BookResponseDto> DeleteBook(long id);

    }
}
