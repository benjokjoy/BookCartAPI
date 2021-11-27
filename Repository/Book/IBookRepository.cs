using Models.DTO;
using Repository.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Models.Entities;

namespace Repository.Book
{
    public interface IBookRepository : IGenericRepository<Entities.Book>
    {
         Task<GetAllBooksResponseDto> GetAllBooks (GetBooksRequestDto request);
         Task<BookResponseDto> CreateBook(BookRequestDto request);
         Task<BookResponseDto> UpdatePrice(long id, decimal price);
         Task<BookResponseDto> UpdateBook(BookRequestDto request);
         Task<BookResponseDto> DeleteBook(long id);



    }
}
