using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : StatusCodeResult
    {
        public string Message { get; set; }
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound)
        {
            Message = message;
        }
    }
}
