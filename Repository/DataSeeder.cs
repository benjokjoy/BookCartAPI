using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities = Models.Entities;

namespace Repository
{
   public  class DataSeeder
    {
        public static void Initialize(BookCartDBContext context)
        {
                context.Books.AddRange(
                    new Entities.Book
                    {
                        Id = 1,
                        Title = "benjo",
                        Author = "ddd",
                        Description = "dd",
                        CoverImage ="da",
                        Price=(decimal) 1534.45,
                        IsDeleted=false
                    },
                    new Entities.Book
                    {
                        Id = 2,
                        Title = "22",
                        Author = "2",
                        Description = "2",
                        CoverImage = "2",
                        Price = (decimal)22222,
                        IsDeleted=false,
                    });

                context.SaveChanges();
            }
      
    } 
}
