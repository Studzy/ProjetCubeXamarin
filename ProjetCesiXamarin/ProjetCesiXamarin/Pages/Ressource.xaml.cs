using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.ViewModels;
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
    public partial class Ressource : TabbedPage
    {
        RessourceViewModel ressourceViewModel;

        public Ressource()
        {
            InitializeComponent();

            BindingContext = ressourceViewModel = new RessourceViewModel();
        }

        protected override void OnAppearing()
        {
            //Task.Run(new Func<Task>(async () => await ressourceViewModel.RefreshView()));

            base.OnAppearing();
        }
    }
}