using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
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
            BindingContext = App.Locator.RessourceViewModel;
        }
    }
}