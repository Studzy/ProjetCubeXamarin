﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Constant;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConnectionViewModel : ViewModelBase
    {
        //private readonly INavigationService _navigationService;

        public ICommand NavigateToInscriptionCommand { get; set; }
        public ICommand LoginUserCommand { get; set; }
        AccountService _accountService = new AccountService();

        public ConnectionViewModel(INavigationService navigationService)
        {
            //_navigationService = navigationService;
            NavigateToInscriptionCommand = new RelayCommand(async () => await NavigateToInscription());
            LoginUserCommand = new RelayCommand(() => Login());
        }

        public async Task NavigateToInscription()
        {
            //_navigationService.NavigateTo("Inscription");
            await Shell.Current.GoToAsync("//Inscription");
        }

        async void Login()
        {
            LoginData loginData = new LoginData();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    loginData.Username = Username;
                    loginData.Password = Password;

                    Tuple<bool, string> loginResult = await _accountService.Login(loginData);

                    if (loginResult.Item1)
                    {
                        await Shell.Current.GoToAsync("//Accueil");
                        Tab resultTab = Shell.Current.FindByName<Tab>("Profil");
                        resultTab.IsVisible = true;
                        resultTab = Shell.Current.FindByName<Tab>("Connection");
                        resultTab.IsVisible = false;
                        resultTab = Shell.Current.FindByName<Tab>("Inscription");
                        resultTab.IsVisible = false;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erreur", loginResult.Item2, "Ok");
                    }
                }
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
