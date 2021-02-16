using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class ListRessource
    {
        public int TypeTri { get; set; }
        public List<RessourceSearch> Ressources { get; set; }

    }

    public class RessourceSearch
    {
        public int Id { get; set; }
        public string Titre { get; set; }
    }
}
