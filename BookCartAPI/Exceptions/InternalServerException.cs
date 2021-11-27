using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InternalServerException : StatusCodeResult
    {
        public string Message { get; set; }
        public InternalServerException(string message) : base(StatusCodes.Status500InternalServerError)
        {
            Message = message;
        }
    }
}
