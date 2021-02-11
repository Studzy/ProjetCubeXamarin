using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetCesiXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ressource : ContentPage
    {
        public Ressource()
        {
            InitializeComponent();
            BindingContext = App.Locator.RessourceViewModel;
        }
        public Ressource(RessourceData ressource)
        {
            InitializeComponent();
            App.Locator.RessourceViewModel.Ressource = ressource;
            App.Locator.RessourceViewModel.Categorie = ressource.Categorie.Nom;
            App.Locator.RessourceViewModel.TypeRessource = ressource.TypeRessource.Nom;
            App.Locator.RessourceViewModel.TypeRelations = ressource.TypeRelations.Select(c => c.Nom).ToList();
            BindingContext = App.Locator.RessourceViewModel;
        }
    }
}