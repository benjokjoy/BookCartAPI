using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationException : StatusCodeResult
    {
        public string Message { get; set; }
        public AuthenticationException(string message) : base(StatusCodes.Status401Unauthorized)
        {
            Message = message;
        }
    }
}
