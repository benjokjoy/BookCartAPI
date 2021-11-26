using Repository.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookCartDBContext _dbContext;
        public BookRepository Books { get; }
       

        public UnitOfWork(BookCartDBContext dbContext,BookRepository booksRepository)
        {
            this._dbContext = dbContext;

            this.Books = booksRepository;
           
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
