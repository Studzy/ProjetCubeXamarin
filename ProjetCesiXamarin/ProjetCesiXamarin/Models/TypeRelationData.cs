using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class TypeRelationData
    {
        [JsonProperty("Nom")]
        public string Nom { get; set; }
    }

    public enum TypeRelations
    {
        [JsonProperty("Id")]
        Soi = 1,
        Conjoints,
        Famille,
        Professionnelle,
        Amis,
        Inconnus
    }
}
