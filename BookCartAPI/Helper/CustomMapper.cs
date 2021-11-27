using AutoMapper;
using BookCartAPI.RequestResponseModels;
using Models.DTO;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Helper
{
    [ExcludeFromCodeCoverage]
    public class CustomMapper:Profile
    {
        public CustomMapper()
        {
            CreateMap<GetBooksRequest, GetBooksRequestDto>();
            CreateMap<BookResponseDto, BooksResponse>();
            CreateMap<UpdateBookRequest, BookRequestDto>();
            CreateMap<CreateBookRequest, BookRequestDto>();
            CreateMap<GetAllBooksResponseDto, GetAllBooksResponse>();
          
        }
    }
}
