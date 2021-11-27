using AutoMapper;
using BookCartAPI.Controllers;
using BookCartAPI.Helper;
using BookCartAPI.RequestResponseModels;
using CoreBusiness.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BookCartAPI.xTests.Book
{

    public class BookControllerTest
    {
        private IMapper _mapper;
        private Mock<IBookService> _bookService;
        GetBooksRequest getAllBooksRequest = new GetBooksRequest { TitleSearch = "", PageNum = 1, PageSize = 10 };
        UpdateBookRequest updateBookRequest = new UpdateBookRequest { Id = 2, Title = "Arms and the Man", Author = "George Bernard Shaw", Description = "Arms and the Man is a comedy", CoverImage = "ArmsandtheMan.jpeg", Price = (decimal)250 };
        CreateBookRequest createBookRequest = new CreateBookRequest { Title = "Sherlock Holmes", Author = "Arthur Conan Doyle", Description = "Sherlock Holmes is a fictional detective", CoverImage = "Sherlok.jpeg", Price = (decimal)150 };
        public BookControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                  {
                      mc.AddProfile(new CustomMapper());
                  });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _bookService = new Mock<IBookService>();

        }

        #region GetAllBooks
        [Fact]
        public void GetAllBooks_Controller_Test()
        {
            List<BookResponseDto> serviceResponseObj = new List<BookResponseDto>() {
            new BookResponseDto{ Id = 2, Title = "Arms and the Man",Author = "G.B.Shaw",Description = "Arms and the Man is a comedy by George Bernard Shaw",CoverImage = "ArmsandtheMan.jpeg",Price = (decimal)222.9},
            new BookResponseDto{Id = 1, Title = "Ancient Mariner", Author = "Coleridge",Description = "Rime of the Ancient Mariner tells of the misfortunes of a seaman who shoots an albatross, which spells disaster for his ship and fellow sailors.",CoverImage = "AncientMariner.jpeg",Price=(decimal) 156 }
            };

            _bookService.Setup(x => x.GetAllBooks(It.IsAny<GetBooksRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.GetAllBooks(getAllBooksRequest).Result;
            var response = (List<BooksResponse>)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("Arms and the Man", response.FirstOrDefault().Title);
            Assert.Equal(2, response.Count);
        }
        [Fact]
        public void GetAllBooks_Controller_NoData_Test()
        {
            List<BookResponseDto> serviceResponseObj = null;

            _bookService.Setup(x => x.GetAllBooks(It.IsAny<GetBooksRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.GetAllBooks(getAllBooksRequest).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void GetAllBooks_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.GetAllBooks(It.IsAny<GetBooksRequestDto>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.GetAllBooks(getAllBooksRequest).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion
        #region GetBook
        [Fact]
        public void GetBook_Controller_Test()
        {
            BookResponseDto serviceResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)222.9
            };
            _bookService.Setup(x => x.GetBook(It.IsAny<long>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.GetBook(2).Result;
            var response = (BooksResponse)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("Arms and the Man", response.Title);
        }
        [Fact]
        public void GetBook_Controller_NoData_Test()
        {
            BookResponseDto serviceResponseObj = null;

            _bookService.Setup(x => x.GetBook(It.IsAny<long>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.GetBook(1000).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void GetBook_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.GetBook(It.IsAny<long>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.GetBook(2).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion
        #region CreateBook
        [Fact]
        public void CreateBook_Controller_Test()
        {
            BookResponseDto serviceResponseObj = new BookResponseDto()
            {
                Id = 3,
                Title = "Sherlock Holmes",
                Author = "Arthur Conan Doyle",
                Description = "Sherlock Holmes is a fictional detective",
                CoverImage = "Sherlok.jpeg",
                Price = (decimal)150
            };
            _bookService.Setup(x => x.CreateBook(It.IsAny<BookRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.CreateBook(createBookRequest).Result;
            var response = (BooksResponse)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal(3, response.Id);
            Assert.Equal("Arthur Conan Doyle", response.Author);
            Assert.Equal("Sherlock Holmes", response.Title);
            Assert.Equal(150, response.Price);
        }
        [Fact]
        public void CreateBook_Controller_NoData_Test()
        {
            BookResponseDto serviceResponseObj = null;

            _bookService.Setup(x => x.CreateBook(It.IsAny<BookRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.CreateBook(createBookRequest).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void CreateBook_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.CreateBook(It.IsAny<BookRequestDto>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.CreateBook(createBookRequest).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion
        #region UpdatePrice
        [Fact]
        public void UpdatePrice_Controller_Test()
        {
            BookResponseDto serviceResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)555
            };
            _bookService.Setup(x => x.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.UpdatePrice(2, 555).Result;
            var response = (BooksResponse)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal(555, response.Price);
        }
        [Fact]
        public void UpdatePrice_Controller_NoData_Test()
        {
            BookResponseDto serviceResponseObj = null;

            _bookService.Setup(x => x.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.UpdatePrice(1000, 555).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void UpdatePrice_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.UpdatePrice(2, 555).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion
        #region UpdateBook
        [Fact]
        public void UpdateBook_Controller_Test()
        {
            BookResponseDto serviceResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "George Bernard Shaw",
                Description = "Arms and the Man is a comedy",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)250
            };
            _bookService.Setup(x => x.UpdateBook(It.IsAny<BookRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.UpdateBook(updateBookRequest).Result;
            var response = (BooksResponse)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("George Bernard Shaw", response.Author);
            Assert.Equal("Arms and the Man is a comedy", response.Description);
            Assert.Equal(250, response.Price);
        }
        [Fact]
        public void UpdateBook_Controller_NoData_Test()
        {
            BookResponseDto serviceResponseObj = null;

            _bookService.Setup(x => x.UpdateBook(It.IsAny<BookRequestDto>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.UpdateBook(updateBookRequest).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void UpdateBook_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.UpdateBook(It.IsAny<BookRequestDto>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.UpdateBook(updateBookRequest).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion
        #region DeleteBook
        [Fact]
        public void DeleteBook_Controller_Test()
        {
            BookResponseDto serviceResponseObj = new BookResponseDto()
            {
                Id = 2,
                Title = "Arms and the Man",
                Author = "G.B.Shaw",
                Description = "Arms and the Man is a comedy by George Bernard Shaw",
                CoverImage = "ArmsandtheMan.jpeg",
                Price = (decimal)222.9
            };
            _bookService.Setup(x => x.DeleteBook(It.IsAny<long>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.DeleteBook(2).Result;
            var response = (string)result.Value;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("Deleted Successfully", response);
        }
        [Fact]
        public void DeleteBook_Controller_NoData_Test()
        {
            BookResponseDto serviceResponseObj = null;

            _bookService.Setup(x => x.DeleteBook(It.IsAny<long>())).ReturnsAsync(serviceResponseObj);

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (StatusCodeResult)controllerObj.DeleteBook(1000).Result;
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);

        }
        [Fact]
        public void DeleteBook_Controller_Exception_Test()
        {
            _bookService.Setup(x => x.DeleteBook(It.IsAny<long>())).Throws(new Exception());

            var controllerObj = new BookController(_mapper, _bookService.Object);
            var result = (ObjectResult)controllerObj.DeleteBook(2).Result;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
        #endregion



    }
}
