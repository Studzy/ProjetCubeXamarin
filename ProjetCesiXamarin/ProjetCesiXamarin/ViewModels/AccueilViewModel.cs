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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class AccueilViewModel : ViewModelBase
    {
        public ObservableCollection<RessourceAccueil> _dernieresRessources;
        public ObservableCollection<RessourceAccueil> _ressourcePlusConsultees;

        public ICommand TappedItemCommand { get; set; }

        public AccueilViewModel()
        {

            Task.Run(new Func<Task>(() => InitData()));  
            TappedItemCommand = new RelayCommand<RessourceAccueil>(async (ressource) => await NavigateToTappedItem(ressource));
        }

        async Task InitData()
        {
            var data = await new AccueilService().GetAccueilData();

            DerniereRessources = data.RessourcesPlusRecentes;
            RessourcePlusConsultees = data.RessourcesPlusVues;
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
