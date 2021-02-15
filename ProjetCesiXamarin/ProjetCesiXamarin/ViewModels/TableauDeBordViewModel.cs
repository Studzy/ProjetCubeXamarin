using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Pages;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class TableauDeBordViewModel : ViewModelBase
    {
        public ICommand GoToRessourceCommand { get; set; }
        public ICommand NavigateToRessourcesFavoritesPageCommand { get; set; }
        public ICommand NavigateToRessourcesExploitePageCommand { get; set; }
        public ICommand NavigateToRessourcesMisCotePageCommand { get; set; }
        public ICommand NavigateToRessourcesCreesPageCommand { get; set; }
        public TableauDeBordViewModel(string page)
        {
            GoToRessourceCommand = new RelayCommand<RessourceTableauBord>(async (ressource) => await NavigateToRessource(ressource));
            NavigateToRessourcesFavoritesPageCommand = new RelayCommand(async () => await NavigateToRessourcesFavoritesPage());
            NavigateToRessourcesExploitePageCommand = new RelayCommand(async () => await NavigateToRessourcesExploitePage());
            NavigateToRessourcesMisCotePageCommand = new RelayCommand(async () => await NavigateToRessourcesMisCotePage());
            NavigateToRessourcesCreesPageCommand = new RelayCommand(async () => await NavigateToRessourcesCreesPage());
            if (page == "favoris")
            {
                Task.Run(new Func<Task>(() => InitDataFavoris()));
            }
            if (page == "exploite")
            {
                Task.Run(new Func<Task>(() => InitDataExploite()));
            }
            if (page == "miscote")
            {
                Task.Run(new Func<Task>(() => InitDataMisCote()));
            }
            if (page == "crees")
            {
                Task.Run(new Func<Task>(() => InitDataCrees()));
            }
        }

        public async Task NavigateToRessourcesFavoritesPage()
        {
            Routing.RegisterRoute(nameof(RessourcesFavoritesPage), typeof(RessourcesFavoritesPage));
            await Shell.Current.GoToAsync($"{nameof(RessourcesFavoritesPage)}");
        }

        public async Task NavigateToRessourcesExploitePage()
        {
            Routing.RegisterRoute(nameof(RessourcesExploitePage), typeof(RessourcesExploitePage));
            await Shell.Current.GoToAsync($"{nameof(RessourcesExploitePage)}");
        }
        public async Task NavigateToRessourcesMisCotePage()
        {
            Routing.RegisterRoute(nameof(RessourcesMisCotePage), typeof(RessourcesMisCotePage));
            await Shell.Current.GoToAsync($"{nameof(RessourcesMisCotePage)}");
        }
        public async Task NavigateToRessourcesCreesPage()
        {
            Routing.RegisterRoute(nameof(RessourcesCreesPage), typeof(RessourcesCreesPage));
            await Shell.Current.GoToAsync($"{nameof(RessourcesCreesPage)}");
        }
        public async Task NavigateToRessource(RessourceTableauBord ressource)
        {
            Routing.RegisterRoute(nameof(Ressource), typeof(Ressource));
            await Shell.Current.GoToAsync($"{nameof(Ressource)}?RessourceId={ressource.Id}");
        }

        async Task InitDataFavoris()
        {
            var data = await new TableauDeBordService().GetRessourcesFavorites();

            Ressources = data.Ressources;
        }

        async Task InitDataExploite()
        {
            var data = await new TableauDeBordService().GetRessourcesExploite();

            Ressources = data.Ressources;
        }

        async Task InitDataMisCote()
        {
            var data = await new TableauDeBordService().GetRessourcesMisCote();

            Ressources = data.Ressources;
        }

        async Task InitDataCrees()
        {
            var data = await new TableauDeBordService().GetRessourcesCrees();

            Ressources = data.Ressources;
        }

        private string _nomVue;

        public string NomVue
        {
            get { return _nomVue; }
            set
            {
                _nomVue = value;
                RaisePropertyChanged();
            }
        }

        private string _tri;

        public string Tri
        {
            get { return _tri; }
            set
            {
                _tri = value;
                RaisePropertyChanged();
            }
        }

        private string _recherche;

        public string Recherche
        {
            get { return _recherche; }
            set
            {
                _recherche = value;
                RaisePropertyChanged();
            }
        }

        private int _page;

        public int Page
        {
            get { return _page; }
            set
            {
                _page = value;
                RaisePropertyChanged();
            }
        }

        private int _nombrePages;

        public int NombrePages
        {
            get { return _nombrePages; }
            set
            {
                _nombrePages = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RessourceTableauBord> _ressources;
        public ObservableCollection<RessourceTableauBord> Ressources
        {
            get { return _ressources; }
            set
            {
                _ressources = value;
                RaisePropertyChanged();
            }
        }
    }
}
