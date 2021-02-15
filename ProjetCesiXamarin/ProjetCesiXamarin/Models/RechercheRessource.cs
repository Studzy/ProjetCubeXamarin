using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class RechercheRessource
    {
        [JsonProperty("Recherche")]
        public string Recherche { get; set; }

        [JsonProperty("SelectedTypeRelation")]
        public List<int> SelectedTypeRelation { get; set; }

        [JsonProperty("SelectedCategories")]
        public List<int> SelectedCategories { get; set; }

        [JsonProperty("SelectedTypeRessources")]
        public List<int> SelectedTypeRessources { get; set; }

        [JsonProperty("DateDebut")]
        public DateTime? DateDebut { get; set; }

        [JsonProperty("DateFin")]
        public DateTime? DateFin { get; set; }

        public int Page { get; set; }

        public ListRessource Ressources { get; set; } = new ListRessource();
    }
}
