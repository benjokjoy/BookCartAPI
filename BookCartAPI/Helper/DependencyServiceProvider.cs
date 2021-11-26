using CoreBusiness.Book;
using Microsoft.Extensions.DependencyInjection;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Helper
{
    public static class DependencyServiceProvider 
    {
        public static IServiceCollection ServiceRegistry(this IServiceCollection services)
        {
            //services
            services.AddScoped<IBookService, BookService>();

            //repositories
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
