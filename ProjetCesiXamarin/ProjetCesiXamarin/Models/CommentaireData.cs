using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class CommentaireData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("DateCreation")]
        public DateTimeOffset DateCreation { get; set; }
        [JsonProperty("DateModification")]
        public DateTimeOffset DateModification { get; set; }
        [JsonProperty("Texte")]
        public string Texte { get; set; }
        [JsonProperty("Utilisateur")]
        public UserData Utilisateur { get; set; }
        [JsonProperty("UtilisateurId")]
        public int? UtilisateurId { get; set; }
        [JsonProperty("Ressource")]
        public RessourceData Ressource { get; set; }
        [JsonProperty("RessourceId")]
        public int RessourceId { get; set; }
        [JsonProperty("CommentaireParent")]
        public CommentaireData CommentaireParent { get; set; }
        [JsonProperty("CommentaireParentId")]
        public int? CommentaireParentId { get; set; }
        [JsonProperty("CommentairesEnfant")]
        public List<CommentaireData> CommentairesEnfant { get; set; }
    }
}
