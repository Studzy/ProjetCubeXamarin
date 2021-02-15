using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetCesiXamarin.Models
{
    public class TableauDeBordData
    {
        public string NomVue { get; set; }

        public string Tri { get; set; }

        public int Page { get; set; }

        public int NombrePages { get; set; }
        public string Recherche { get; set; }

        public ObservableCollection<RessourceTableauBord> Ressources { get; set; }
    }

    public class RessourceTableauBord
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public Statut Statut { get; set; }
        public CategorieData Categorie { get; set; }
        public TypeRessourceData TypeRessource { get; set; }
        public List<TypeRelationRessourceData> TypeRelationsRessources { get; set; }
    }
}
