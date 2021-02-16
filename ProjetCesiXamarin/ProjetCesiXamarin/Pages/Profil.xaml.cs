using ProjetCesiXamarin.ViewModels;
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
    public partial class Profil : ContentPage
    {
        ProfilViewModel profilViewModel = new ProfilViewModel();
        public Profil()
        {
            InitializeComponent();
            BindingContext = profilViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(new Func<Task>(() => profilViewModel.InitProfil()));
        }
    }
}