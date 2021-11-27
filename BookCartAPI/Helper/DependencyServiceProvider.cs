using BookCartAPI.Auth;
using CoreBusiness.Book;
using CoreBusiness.User;
using Microsoft.Extensions.DependencyInjection;
using Repository.Book;
using Repository.User;
using System.Diagnostics.CodeAnalysis;
namespace BookCartAPI.Helper
{
    [ExcludeFromCodeCoverage]
    public static class DependencyServiceProvider 
    {
        public static IServiceCollection ServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuth, JwtAuth>();

            //services
            services.AddScoped<IBookService, BookService>();         
            services.AddScoped<IUserService, UserService>();

            //repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            

            return services;
        }
    }
}
