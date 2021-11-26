using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{
    
    public class NotFoundException : StatusCodeResult
    {
        public string Message { get; set; }
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound)
        {
            Message = message;
        }
    }
}
