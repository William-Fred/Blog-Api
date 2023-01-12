using System;

namespace BlogProjectAPI.Models.Auth
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
