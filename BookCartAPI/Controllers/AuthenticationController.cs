using BookCartAPI.Auth;
using BookCartAPI.Exceptions;
using BookCartAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace BookCartAPI.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuth _jwtAuth;
        private readonly ILogger _logger;

        public AuthenticationController(IJwtAuth jwtAuth)
        {
            this._jwtAuth = jwtAuth;
            _logger = Serilog.Log.ForContext<BookController>();
        }
        /// <summary>
        /// This method is used for getting the bearer token using username and password
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns>TokenResponse</returns>
        [AllowAnonymous]
        [HttpPost("GetJWTBearerToken")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]       
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestException))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerException))]
        public async Task<IActionResult> GetJWTBearerToken(TokenRequest userCredential)
        {
            try
            {
                var token =await _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
                if (token != null)
                {
                    
                    _logger.Write(LogEventLevel.Information, LoggerTemplate.Success, "GetBearerToken", StatusCodes.Status200OK);
                    return StatusCode(StatusCodes.Status200OK, token);
                }
                else
                {
                    _logger.Write(LogEventLevel.Warning, LoggerTemplate.Error, "GetBearerToken", StatusCodes.Status204NoContent);
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(LogEventLevel.Error, LoggerTemplate.Error, "GetBearerToken", ex.Message, StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerException(ex.Message));
            }

        }
    }
}
