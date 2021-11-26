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
                        Title = "Ancient Mariner",
                        Author = "Coleridge",
                        Description = "Rime of the Ancient Mariner tells of the misfortunes of a seaman who shoots an albatross, which spells disaster for his ship and fellow sailors.",
                        CoverImage = "AncientMariner.jpeg",
                        Price=(decimal) 156,
                        CreatedDate=DateTime.Now,
                        IsDeleted=false
                    },
                    new Entities.Book
                    {
                        Id = 2,
                        Title = "Arms and the Man",
                        Author = "G.B.Shaw",
                        Description = "Arms and the Man is a comedy by George Bernard Shaw",
                        CoverImage = "ArmsandtheMan.jpeg",
                        Price = (decimal)222.9,
                        CreatedDate = DateTime.Now,
                        IsDeleted =false,
                    });

                context.SaveChanges();
            }
      
    } 
}
