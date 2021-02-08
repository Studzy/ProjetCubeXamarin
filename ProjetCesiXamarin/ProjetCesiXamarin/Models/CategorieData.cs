using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class CategorieData
    {
        [JsonProperty("Nom")]
        public string Nom { get; set; }
        [JsonProperty("Ressources")]
        public List<RessourceData> Ressources { get; set; }
    }
}
