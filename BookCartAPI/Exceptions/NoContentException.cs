using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NoContentException : StatusCodeResult
    {
        public string Message { get; set; }
        public NoContentException(string message) : base(StatusCodes.Status204NoContent)
        {
            Message = message;
        }
    }
}
