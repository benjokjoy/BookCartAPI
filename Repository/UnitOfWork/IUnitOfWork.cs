using Repository.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        BookRepository Books { get; }      
        int Complete();
    }
}
