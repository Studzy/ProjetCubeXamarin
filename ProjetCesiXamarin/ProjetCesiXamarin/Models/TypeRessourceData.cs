using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class TypeRessourceData
    {
        [JsonProperty("Nom")]
        public string Nom { get; set; }
    }

    public enum TypeRessources
    {
        [JsonProperty("Id")]
        ActiviteJeu = 1,
        Article,
        CarteDefi,
        PDF,
        Exercice,
        FicheLecture,
        Jeu,
        Video
    }
}
