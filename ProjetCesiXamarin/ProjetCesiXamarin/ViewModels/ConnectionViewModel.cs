using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConnectionViewModel
    {
        private readonly INavigationService _navigationService;


        public ICommand NavigateToInscriptionCommand { get; set; }

        public ConnectionViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToInscriptionCommand = new RelayCommand(() => NavigateToInscription());
        }

        public void NavigateToInscription()
        {
            _navigationService.NavigateTo("Inscription");
        }
    }
}
