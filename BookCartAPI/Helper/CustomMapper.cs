using AutoMapper;
using BookCartAPI.RequestResponseModels;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Helper
{
    public class CustomMapper:Profile
    {
        public CustomMapper()
        {
            CreateMap<GetBooksRequest, GetBooksRequestDto>();
            CreateMap<BookResponseDto, BooksResponse>();
            CreateMap<UpdateBookRequest, BookRequestDto>();
            CreateMap<CreateBookRequest, BookRequestDto>();
          
        }
    }
}
