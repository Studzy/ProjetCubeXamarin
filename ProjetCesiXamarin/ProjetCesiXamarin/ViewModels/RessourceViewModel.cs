using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCesiXamarin.ViewModels
{
    public class RessourceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RessourceData _ressource;

        public RessourceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
    }
}
