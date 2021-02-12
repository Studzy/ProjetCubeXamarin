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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _userName;
        private bool _userIsConnected;

        public ICommand LoggoutCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoggoutCommand = new RelayCommand(() => Loggout());
            Task.Factory.StartNew(new Func<Task>(async () => await InitData())).Unwrap().Wait();

            Routing.RegisterRoute("ressource", typeof(Ressource));
        }

        private void Loggout()
        {
            SecureStorage.Remove("token");
            SecureStorage.Remove("expiration");
            SecureStorage.Remove("username");

            UserName = null;
        }

        async Task InitData()
        {
            var token = await SecureStorage.GetAsync("token");
            var expiration = await SecureStorage.GetAsync("expiration");
            var username = await SecureStorage.GetAsync("username");

            if (!string.IsNullOrEmpty(expiration))
            {
                DateTime dateExpiration = new DateTime(long.Parse(expiration));

                if (!string.IsNullOrEmpty(token) && dateExpiration != default && !string.IsNullOrEmpty(username))
                {
                    if (DateTime.Now > dateExpiration)
                    {
                        SecureStorage.Remove("token");
                        SecureStorage.Remove("expiration");
                        SecureStorage.Remove("username");
                        UserIsConnected = false;
                    }
                    else
                    {
                        UserName = username;
                        UserIsConnected = true;
                    }
                }
                else
                {
                    UserIsConnected = false;
                }
            }
        }

        public bool UserIsConnected
        {
            get { return _userIsConnected; }
            set
            {
                _userIsConnected = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }
    }
}
