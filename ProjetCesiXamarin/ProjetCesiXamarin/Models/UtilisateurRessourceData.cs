using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class UtilisateurRessourceData
    {
        [JsonProperty("EstFavoris")]
        public bool EstFavoris { get; set; }
        [JsonProperty("EstExploite")]
        public bool EstExploite { get; set; }
        [JsonProperty("EstMisDeCote")]
        public bool EstMisDeCote { get; set; }
        [JsonProperty("Utilisateur")]
        public UserData Utilisateur { get; set; }
        [JsonProperty("UtilisateurId")]
        public int UtilisateurId { get; set; }
        [JsonProperty("Ressource")]
        public RessourceData Ressource { get; set; }
        [JsonProperty("RessourceId")]
        public int RessourceId { get; set; }
    }
}
