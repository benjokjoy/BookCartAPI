using Models.DTO;
using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities = Models.Entities;

namespace Repository.Book
{
    public interface IBookRepository : IGenericRepository<Entities.Book>
    {
         Task<List<BookResponseDto>> GetAllBooks (GetBooksRequestDto request);
         Task<BookResponseDto> UpdatePrice(long id, decimal price);
         Task<BookResponseDto> UpdateBook(BookRequestDto request);
         Task<BookResponseDto> DeleteBook(long id);



    }
}
