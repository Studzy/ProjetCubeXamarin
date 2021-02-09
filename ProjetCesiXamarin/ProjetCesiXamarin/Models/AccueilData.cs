using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class AccueilData
    {
        public ObservableCollection<RessourceAccueil> RessourcesPlusVues { get; set; }
        public ObservableCollection<RessourceAccueil> RessourcesPlusRecentes { get; set; }
    }

    public class RessourceAccueil
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Apercu { get; set; }
        public string Categorie { get; set; }
        public string TypeRessource { get; set; }
        public List<string> TypeRelations { get; set; }

    }
}
