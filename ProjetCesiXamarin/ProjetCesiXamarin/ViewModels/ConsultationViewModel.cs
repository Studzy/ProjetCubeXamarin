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
    public class ConsultationViewModel : ViewModelBase
    {
        
        ConsultationService _consultationService = new ConsultationService();

        public ICommand RechercheCommand => new RelayCommand<string>(async(query) => await Search(query));
        public ICommand GoToRessourceCommand { get; set; } 

        public ConsultationViewModel()
        {
            GoToRessourceCommand = new RelayCommand<RessourceSearch>(async (ressource) => await NavigateToRessource(ressource));
        }

        public async Task NavigateToRessource(RessourceSearch ressource)
        {
            Routing.RegisterRoute(nameof(Ressource), typeof(Ressource));
            await Shell.Current.GoToAsync($"{nameof(Ressource)}?RessourceId={ressource.Id}");
        }


        private string _query;
        public string query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChanged();
            }
        }

        public async Task Search(string query)
        {
            RechercheRessource recherche = new RechercheRessource();
            if (!string.IsNullOrWhiteSpace(query))
            {
                recherche.Recherche = query;
                var searchResult = await _consultationService.GetSearch(query);
                Recherche = new ObservableCollection<RessourceSearch>(searchResult.Ressources.Ressources);
            }
        }

        public ObservableCollection<RessourceSearch> _recherche;

        public ObservableCollection<RessourceSearch> Recherche
        {
            get { return _recherche;}
            set
            {
                _recherche = value;
                RaisePropertyChanged();
            }
        }

    }
}
