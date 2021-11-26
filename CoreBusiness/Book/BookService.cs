using Models.DTO;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities = Models.Entities;
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

        public async Task<BookResponseDto> CreateBook(BookRequestDto request)
        {
            try
            {
                var book = new Entities.Book
                {
                    Title = request.Title,
                    Description = request.Description,
                    Author = request.Author,
                    CoverImage = request.CoverImage,
                    Price = request.Price??0,
                    CreatedDate=DateTime.Now,
                    IsDeleted=false
                };
                 await _bookRepo.Add(book);
                return new BookResponseDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    CoverImage = book.CoverImage,
                    Price = book.Price,
                };
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
