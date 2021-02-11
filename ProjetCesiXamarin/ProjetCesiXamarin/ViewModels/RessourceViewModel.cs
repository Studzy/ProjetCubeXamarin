using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetCesiXamarin.ViewModels
{
    public class RessourceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RessourceData _ressource;
        private string _categorie;
        private string _typeRessource;
        private List<string> _typeRelations;
        public bool _isUserConnected;

        public RessourceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Task.Factory.StartNew(new Func<Task>(async () => await CheckUserIsConnected())).Unwrap().Wait();
        }

        private async Task CheckUserIsConnected()
        {
            if (await SecureStorage.GetAsync("token") != null && await SecureStorage.GetAsync("user") != null)
            {
                IsUserConnected = true;
            }
        }

        public RessourceData Ressource
        {
            get { return _ressource; }
            set
            {
                _ressource = value;
                RaisePropertyChanged();
            }
        }

        public bool IsUserConnected
        {
            get { return _isUserConnected; }
            set
            {
                _isUserConnected = value;
                RaisePropertyChanged();
            }
        }

        public string Categorie
        {
            get { return _categorie; }
            set
            {
                _categorie = value;
                RaisePropertyChanged();
            }
        }

        public string TypeRessource
        {
            get { return _typeRessource; }
            set
            {
                _typeRessource = value;
                RaisePropertyChanged();
            }
        }

        public List<string> TypeRelations
        {
            get { return _typeRelations; }
            set
            {
                _typeRelations = value;
                RaisePropertyChanged();
            }
        }
    }
}
