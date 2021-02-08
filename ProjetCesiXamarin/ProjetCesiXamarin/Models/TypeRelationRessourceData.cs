using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class TypeRelationRessourceData
    {
        [JsonProperty("Ressource")]
        public RessourceData Ressource { get; set; }
        [JsonProperty("RessourceId")]
        public int RessourceId { get; set; }
        [JsonProperty("TypeRelation")]
        public TypeRelationData TypeRelation { get; set; }
        [JsonProperty("TypeRelationId")]
        public int TypeRelationId { get; set; }
    }
}
