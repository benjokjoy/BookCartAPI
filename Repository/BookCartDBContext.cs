using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class BookCartDBContext : DbContext
    {
        public BookCartDBContext(DbContextOptions<BookCartDBContext> options)
       : base(options) {
           

        }

        public DbSet<Models.Entities.Book> Books { get; set; }


       
    }

}
