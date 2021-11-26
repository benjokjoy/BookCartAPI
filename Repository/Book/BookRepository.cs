using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Entities = Models.Entities;
using Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Book
{
    public class BookRepository : GenericRepository<Entities.Book>, IBookRepository
    {

        public BookRepository(BookCartDBContext context) : base(context)
        {

        }
        public async Task<List<BookResponseDto>> GetAllBooks(GetBooksRequestDto request)
        {
            try
            {
                IQueryable<Entities.Book> results = _context.Books;

                // Only filter on title if a search term has been given
                if (!string.IsNullOrEmpty(request.TitleSearch))
                {
                    results = results.Where(s =>
                                  s.Title.ToLower().Contains(request.TitleSearch.ToLower()));
                }

                var resultAfterFilter = await results.Where(i => i.IsDeleted == false).OrderByDescending(x => x.Id)
                              .Skip((request.PageNum - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                if(resultAfterFilter==null)
                {
                    return null;
                }
                return resultAfterFilter.Select(i => new BookResponseDto
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Author = i.Author,
                    CoverImage = i.CoverImage,
                    Price = i.Price
                }).ToList();

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
                var item = await _context.Books.Where(i => i.Id == id&&i.IsDeleted==false).FirstOrDefaultAsync();
                if(item==null)
                {
                    return null;
                }
                item.Price = price;
                item.UpdatedDate = DateTime.Now;
                _context.SaveChanges();
                return new BookResponseDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Author = item.Author,
                    CoverImage = item.CoverImage,
                    Price = item.Price
                };

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
                var item = await _context.Books.Where(i => i.Id == request.Id&&i.IsDeleted==false).FirstOrDefaultAsync();
               if(item==null)
                {
                    return null;
                }
                item.Title = request.Title;
                item.Description = request.Description;
                item.Author = request.Author;
                item.CoverImage = request.CoverImage;              
                item.Price = request.Price??item.Price;                
                item.UpdatedDate = DateTime.Now;
                _context.SaveChanges();
                return new BookResponseDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Author = item.Author,
                    CoverImage = item.CoverImage,
                    Price = item.Price
                }; ;

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
                var item = await _context.Books.Where(i => i.Id == id && i.IsDeleted == false).FirstOrDefaultAsync();
                if (item == null)
                {
                    return null;
                }
                item.IsDeleted = true;
                item.DeletedDate = DateTime.Now;
                _context.SaveChanges();
                return new BookResponseDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Author = item.Author,
                    CoverImage = item.CoverImage,
                    Price = item.Price
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
