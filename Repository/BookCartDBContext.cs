using Microsoft.EntityFrameworkCore;
namespace Repository
{
   public class BookCartDBContext : DbContext
    {
        public BookCartDBContext(DbContextOptions<BookCartDBContext> options)
       : base(options) {
           

        }

        public DbSet<Models.Entities.Book> Books { get; set; }
        public DbSet<Models.Entities.User> Users { get; set; }


       
    }

}
