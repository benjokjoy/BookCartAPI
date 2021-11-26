using AutoMapper;
using BookCartAPI.Helper;
using BookCartAPI.RequestResponseModels;
using CoreBusiness.Book;
using Models.DTO;
using Moq;
using Repository.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Entities = Models.Entities;
namespace BookCartAPI.xTests.Book
{
    public class BookServiceTest
    {

        private Mock<IBookRepository> _bookRepo;
        GetBooksRequestDto getAllBooksRequest = new GetBooksRequestDto { TitleSearch = "", PageNum = 1, PageSize = 10 };
        BookRequestDto updateBookRequest = new BookRequestDto { Id = 2, Title = "Arms and the Man", Author = "George Bernard Shaw", Description = "Arms and the Man is a comedy", CoverImage = "ArmsandtheMan.jpeg", Price = (decimal)250 };
        BookRequestDto createBookRequest = new BookRequestDto { Title = "Sherlock Holmes", Author = "Arthur Conan Doyle", Description = "Sherlock Holmes is a fictional detective", CoverImage = "Sherlok.jpeg", Price = (decimal)150 };
        public BookServiceTest()
        {

            _bookRepo = new Mock<IBookRepository>();

        }
        [Fact]
        public void GetAllBooks_Service_Test()
        {
            List<BookResponseDto> repositoryResponseObj = new List<BookResponseDto>() {
            new BookResponseDto{ Id = 2, Title = "Arms and the Man",Author = "G.B.Shaw",Description = "Arms and the Man is a comedy by George Bernard Shaw",CoverImage = "ArmsandtheMan.jpeg",Price = (decimal)222.9},
            new BookResponseDto{Id = 1, Title = "Ancient Mariner", Author = "Coleridge",Description = "Rime of the Ancient Mariner tells of the misfortunes of a seaman who shoots an albatross, which spells disaster for his ship and fellow sailors.",CoverImage = "AncientMariner.jpeg",Price=(decimal) 156 }
            };

            _bookRepo.Setup(x => x.GetAllBooks(It.IsAny<GetBooksRequestDto>())).ReturnsAsync(repositoryResponseObj);

            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.GetAllBooks(getAllBooksRequest).Result;
            Assert.NotNull(result);
            Assert.Equal("Arms and the Man", result.FirstOrDefault().Title);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public void GetBook_Service_Test()
        {
            Entities.Book repositoryResponseObj = new Entities.Book()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)222.9,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            _bookRepo.Setup(x => x.Get(It.IsAny<long>())).ReturnsAsync(repositoryResponseObj);
            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.GetBook(2).Result;
            Assert.NotNull(result);
            Assert.Equal("Arms and the Man", result.Title);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public void CreateBook_Service_Test()
        {
            
            _bookRepo.Setup(x => x.Add(It.IsAny<Entities.Book>())).Verifiable(); 
            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.CreateBook(createBookRequest).Result;
            Assert.NotNull(result);
            Assert.Equal("Sherlock Holmes", result.Title);
            Assert.Equal("Arthur Conan Doyle", result.Author);
            Assert.Equal(150, result.Price);
        }

        [Fact]
        public void UpdatePrice_Service_Test()
        {
            BookResponseDto repositoryResponseObj= new BookResponseDto()
            { 
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)240,
            };
            _bookRepo.Setup(x => x.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).ReturnsAsync(repositoryResponseObj);
            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.UpdatePrice(2, 240).Result;
            Assert.NotNull(result);
            Assert.Equal(240, result.Price);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public void UpdateBook_Service_Test()
        {
            BookResponseDto repositoryResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)240,
            };
            _bookRepo.Setup(x => x.UpdateBook(It.IsAny<BookRequestDto>())).ReturnsAsync(repositoryResponseObj);
            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.UpdateBook(updateBookRequest).Result;
            Assert.NotNull(result);
            Assert.Equal(240, result.Price);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public void DeleteBook_Service_Test()
        {
            BookResponseDto repositoryResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)240,
            };
            _bookRepo.Setup(x => x.DeleteBook(It.IsAny<long>())).ReturnsAsync(repositoryResponseObj);
            var controllerObj = new BookService(_bookRepo.Object);
            var result = controllerObj.DeleteBook(2).Result;
            Assert.NotNull(result);           
            Assert.Equal(2, result.Id);
        }

    }
}
