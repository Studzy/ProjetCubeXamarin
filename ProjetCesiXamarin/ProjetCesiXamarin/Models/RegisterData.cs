using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class RegisterData
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
