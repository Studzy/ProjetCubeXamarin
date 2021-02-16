using GalaSoft.MvvmLight;
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
        public ICommand NavigateToInscriptionCommand { get; set; }
        public ICommand LoginUserCommand { get; set; }
        AccountService _accountService = new AccountService();
        VisibleService _visibleService = new VisibleService();

        public ConnectionViewModel()
        {
            NavigateToInscriptionCommand = new RelayCommand(async () => await NavigateToInscription());
            LoginUserCommand = new RelayCommand(() => Login());
        }

        public async Task NavigateToInscription()
        {
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
                        _visibleService.VisibleOnConnect();
                        MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
                        menuItem.IsEnabled = true;
                        menuItem.Text = "Se deconnecter";
                        menuItem.IconImageSource = "Logout.png";
                        Shell.Current.FindByName<Tab>("Profil").Title = await SecureStorage.GetAsync("username");
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
