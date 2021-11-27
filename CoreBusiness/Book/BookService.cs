using Models.DTO;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CoreBusiness.Book
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepo)
        {

            this._bookRepo = bookRepo;
        }
        public async Task<List<BookResponseDto>> GetAllBooks(GetBooksRequestDto request)
        {
            try
            {
                return await _bookRepo.GetAllBooks(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<BookResponseDto> GetBook(long id)
        {
            try
            {
                var result = await _bookRepo.Get(id);
                return new BookResponseDto
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Author = result.Author,
                    CoverImage = result.CoverImage,
                    Price = result.Price
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<BookResponseDto> CreateBook(BookRequestDto request)
        {
            try
            {
                return await _bookRepo.CreateBook(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<BookResponseDto> UpdatePrice(long id, decimal price)
        {
            try
            {
                return await _bookRepo.UpdatePrice(id, price);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<BookResponseDto> UpdateBook(BookRequestDto request)
        {
            try
            {
                return await _bookRepo.UpdateBook(request);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<BookResponseDto> DeleteBook(long id)
        {
            try
            {
                return await _bookRepo.DeleteBook(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
