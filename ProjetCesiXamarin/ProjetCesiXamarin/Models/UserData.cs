using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class UserData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("LockoutEnd")]
        public DateTimeOffset? LockoutEnd { get; set; }
        [JsonProperty("TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }
        [JsonProperty("PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("ConcurrencyStamp")]
        public string ConcurrencyStamp { get; set; }
        [JsonProperty("SecurityStamp")]
        public string SecurityStamp { get; set; }
        [JsonProperty("PasswordHash")]
        public string PasswordHash { get; set; }
        [JsonProperty("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }
        [JsonProperty("NormalizedEmail")]
        public string NormalizedEmail { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("NormalizedUserName")]
        public string NormalizedUserName { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("LockoutEnabled")]
        public bool LockoutEnabled { get; set; }
        [JsonProperty("AccessFailedCount")]
        public int AccessFailedCount { get; set; }
        [JsonProperty("UtilisateurRessources")]
        public List<UtilisateurRessourceData> UtilisateurRessources { get; set; }
        [JsonProperty("Commentaires")]
        public List<CommentaireData> Commentaires { get; set; }
        [JsonProperty("RessourcesCree")]
        public List<RessourceData> RessourcesCree { get; set; }
    }
    public enum TypeUtilisateur
    {
        Citoyen = 1,
        Moderateur,
        Admin,
        SuperAdmin
    }
}
