using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartAPI.Exceptions
{
    public class AuthenticationException : StatusCodeResult
    {
        public string Message { get; set; }
        public AuthenticationException(string message) : base(StatusCodes.Status401Unauthorized)
        {
            Message = message;
        }
    }
}
