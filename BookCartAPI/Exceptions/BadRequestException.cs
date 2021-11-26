using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{
   
     public class BadRequestException : StatusCodeResult
    {
        public string Message { get; set; }
        public BadRequestException(string message) : base(StatusCodes.Status400BadRequest)
        {
            Message = message;
        }
    }
}
