using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class LoginData
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }

        [JsonProperty("User")]
        public UserData User { get; set; }
    }
}
