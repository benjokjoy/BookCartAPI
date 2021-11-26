using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{
    
    public class InternalServerException : StatusCodeResult
    {
        public string Message { get; set; }
        public InternalServerException(string message) : base(StatusCodes.Status500InternalServerError)
        {
            Message = message;
        }
    }
}
