using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Pages;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class AccueilViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ObservableCollection<RessourceAccueil> _dernieresRessources;
        public ObservableCollection<RessourceAccueil> _ressourcePlusConsultees;

        public ICommand TappedItemCommand { get; set; }

        public AccueilViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Task.Factory.StartNew(new Func<Task>(async () => await InitData())).Unwrap().Wait();
            TappedItemCommand = new RelayCommand<RessourceAccueil>(async (ressource) => await NavigateToTappedItem(ressource));
        }

        async Task InitData()
        {
            var data = await new AccueilService().GetAccueilData();

            _dernieresRessources = data.RessourcesPlusRecentes;
            _ressourcePlusConsultees = data.RessourcesPlusVues;
        }

        private async Task NavigateToTappedItem(RessourceAccueil ressource)
        {
            Routing.RegisterRoute(nameof(Ressource), typeof(Ressource));
            await Shell.Current.GoToAsync($"{nameof(Ressource)}?RessourceId={ressource.Id}");
        }

        public ObservableCollection<RessourceAccueil> DerniereRessources
        {
            get { return _dernieresRessources; }
            set
            {
                _dernieresRessources = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RessourceAccueil> RessourcePlusConsultees
        {
            get { return _ressourcePlusConsultees; }
            set
            {
                _ressourcePlusConsultees = value;
                RaisePropertyChanged();
            }
        }
    }
}
