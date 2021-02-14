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

        public ObservableCollection<RessourceData> Ressources { get; set; }
    }
}
