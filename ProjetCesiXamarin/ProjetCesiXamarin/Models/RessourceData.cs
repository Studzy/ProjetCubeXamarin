using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class RessourceData
    {
        [JsonProperty("RessourceId")]
        public int RessourceId { get; set; }
        [JsonProperty("DateCreation")]
        public DateTimeOffset DateCreation { get; set; }
        [JsonProperty("DateModification")]
        public DateTimeOffset DateModification { get; set; }
        [JsonProperty("Titre")]
        public string Titre { get; set; }
        [JsonProperty("Contenu")]
        public string Contenu { get; set; }
        [JsonProperty("Statut")]
        public Statut Statut { get; set; }
        [JsonProperty("NombreConsultation")]
        public int NombreConsultation { get; set; }
        [JsonProperty("UtilisateurCreateur")]
        public UserData UtilisateurCreateur { get; set; }
        [JsonProperty("TypeRessource")]
        public TypeRessourceData TypeRessource { get; set; }
        [JsonProperty("Categorie")]
        public CategorieData Categorie { get; set; }
        [JsonProperty("EstFavoris")]
        public bool EstFavoris { get; set; }
        [JsonProperty("EstExploite")]
        public bool EstExploite { get; set; }
        [JsonProperty("EstMisDeCote")]
        public bool EstMisDeCote { get; set; }
        [JsonProperty("TypeRelations")]
        public List<TypeRelationData> TypeRelations { get; set; }
        [JsonProperty("Commentaires")]
        public List<CommentaireData> Commentaires { get; set; }
        [JsonProperty("RessourceSupprime")]
        public bool RessourceSupprime { get; set; }
        [JsonProperty("DateSuppression")]
        public DateTimeOffset DateSuppression { get; set; }
        [JsonProperty("TypePartage")]
        public TypePartage TypePartage { get; set; }
        [JsonProperty("ShareURL")]
        public string ShareURL { get; set; }

    }

    public enum TypePartage
    {
        Public,
        Partage,
        Prive
    }

    public enum Statut
    {
        Empty,
        EnPause,
        AttenteValidation,
        Accepter,
        Refuser,
        Suspendre
    }
}



