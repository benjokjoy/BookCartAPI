using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{

    public class NoContentException : StatusCodeResult
    {
        public string Message { get; set; }
        public NoContentException(string message) : base(StatusCodes.Status204NoContent)
        {
            Message = message;
        }
    }
}
