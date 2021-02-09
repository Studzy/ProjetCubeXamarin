using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Constant;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConnectionViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand NavigateToInscriptionCommand { get; set; }
        public ICommand LoginUserCommand { get; set; }
        AccountService _accountService = new AccountService();

        public ConnectionViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToInscriptionCommand = new RelayCommand(() => NavigateToInscription());
            LoginUserCommand = new RelayCommand(() => Login());
        }

        public void NavigateToInscription()
        {
            _navigationService.NavigateTo("Inscription");
        }

        async void Login()
        {
            var test = await SecureStorage.GetAsync("token");

            LoginData loginData = new LoginData();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    loginData.Username = Username;
                    loginData.Password = Password;

                    var ResultRegister = await _accountService.Login(loginData);
                }
             }
            else
            {
                //Temperature = "No Internet";
                //ColorText = "Red";

            }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }
    }
}
