using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BadRequestException : StatusCodeResult
    {
        public string Message { get; set; }
        public BadRequestException(string message) : base(StatusCodes.Status400BadRequest)
        {
            Message = message;
        }
    }
}
