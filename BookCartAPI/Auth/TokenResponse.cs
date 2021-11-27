using System;
using System.Diagnostics.CodeAnalysis;

namespace BookCartAPI.Auth
{
    [ExcludeFromCodeCoverage]
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
