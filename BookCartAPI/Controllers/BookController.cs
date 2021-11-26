using AutoMapper;
using BookCartAPI.Exceptions;
using BookCartAPI.RequestResponseModels;
using CoreBusiness.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using BookCartAPI.Helper;
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace BookCartAPI.Controllers
{

    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly ILogger _logger;


        public BookController(IMapper mapper, IBookService bookService)
        {
            this._mapper = mapper;
            this._bookService = bookService;
            _logger = Serilog.Log.ForContext<BookController>();
        }

        /// <summary>
        /// This will provide all book's details according to the filtering parrameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List<BooksResponse></returns>
        [HttpPost]
        [Route("GetAllBooks")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BooksResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> GetAllBooks(GetBooksRequest request)
        {
            try
            {
                    GetBooksRequestDto reqDto = _mapper.Map<GetBooksRequestDto>(request);
                    List<BookResponseDto> resultDto = await _bookService.GetAllBooks(reqDto);
                    if (resultDto != null)
                    {
                        List<BooksResponse> response = _mapper.Map<List<BooksResponse>>(resultDto);
                        _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "GetAllBooks", StatusCodes.Status200OK);
                        return StatusCode(StatusCodes.Status200OK, response);
                    }
                    else
                    {
                        _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "GetAllBooks", StatusCodes.Status200OK);
                        return StatusCode(StatusCodes.Status204NoContent);
                    }
               
            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "GetAllBooks", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }



        /// <summary>
        /// This will provide the details of a book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BooksResponse</returns>
        [HttpGet]
        [Route("GetBook/{id}")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> GetBook(long id)
        {
            try
            {

                BookResponseDto resultDto = await _bookService.GetBook(id);
                if (resultDto != null)
                {
                    BooksResponse response = _mapper.Map<BooksResponse>(resultDto);
                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "GetBook", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "GetBook", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "GetBook", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }


        /// <summary>
        /// This will allow user to update the price of a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns>BooksResponse</returns>
        [HttpPatch]
        [Route("UpdatePrice/{id}")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> UpdatePrice(long id, [FromBody] decimal price)
        {
            try
            {
                BookResponseDto resultDto = await _bookService.UpdatePrice(id, price);
                if (resultDto != null)
                {
                    BooksResponse response = _mapper.Map<BooksResponse>(resultDto);
                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "UpdatePrice", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "UpdatePrice", StatusCodes.Status204NoContent);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "UpdatePrice", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }


        /// <summary>
        /// This will allow user to update the book details
        /// </summary>
        /// <param name="request"></param>
        /// <returns>BooksResponse</returns>
        [HttpPut]
        [Route("UpdateBook")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
        {
            try
            {
                BookRequestDto reqDto = _mapper.Map<BookRequestDto>(request);
                BookResponseDto resultDto = await _bookService.UpdateBook(reqDto);
                if (resultDto != null)
                {
                    BooksResponse response = _mapper.Map<BooksResponse>(resultDto);
                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "UpdateBook", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "UpdateBook", StatusCodes.Status204NoContent);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "UpdateBook", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }

        /// <summary>
        /// This will allow user to create a new book
        /// </summary>
        /// <param name="request"></param>
        /// <returns>BooksResponse</returns>
        [HttpPost]
        [Route("CreateBook")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> CreateBook(CreateBookRequest request)
        {
            try
            {
                BookRequestDto reqDto = _mapper.Map<BookRequestDto>(request);
                BookResponseDto resultDto = await _bookService.CreateBook(reqDto);
                if (resultDto != null)
                {
                    BooksResponse response = _mapper.Map<BooksResponse>(resultDto);
                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "CreateBook", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "CreateBook", StatusCodes.Status204NoContent);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "CreateBook", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }

        /// <summary>
        /// This will allow user to delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> DeleteBook(long id)
        {
            try
            {
                BookResponseDto resultDto = await _bookService.DeleteBook(id);
                if (resultDto != null)
                {

                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "DeleteBook", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, "Deleted Successfully");
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Success, "DeleteBook", StatusCodes.Status204NoContent);
                    return StatusCode(StatusCodes.Status204NoContent);
                }

            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "DeleteBook", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }
    }
}
