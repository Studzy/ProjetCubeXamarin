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
        VisibleService _visibleService = new VisibleService();

        private string _userName;
        private bool _userIsConnected;

        public ICommand LoggoutCommand { get; set; }

        //public MainPageViewModel(INavigationService navigationService)
        public MainPageViewModel()
        {
            //_navigationService = navigationService;

            LoggoutCommand = new RelayCommand(async() => await LoggoutAsync());
            Task.Factory.StartNew(new Func<Task>(async () => await InitData())).Unwrap().Wait();
            //Task.Factory.StartNew(()=> TabVisible());

            Routing.RegisterRoute("ressource", typeof(Ressource));
        }

        private async Task LoggoutAsync()
        {
            SecureStorage.Remove("token");
            SecureStorage.Remove("expiration");
            SecureStorage.Remove("username");

            UserName = null;
            _visibleService.VisibleOnDisconnect();
            MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
            menuItem.IsEnabled = false;
            menuItem.Text = "";
            menuItem.IconImageSource = "";
            await Shell.Current.GoToAsync("//Accueil");
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

        public void TabVisible()
        {
            var Connected = UserIsConnected;
            if (Connected)
            {
                _visibleService.VisibleOnConnect();
                MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
                menuItem.IsEnabled = true;
                menuItem.Text = "Se deconnecter";
                menuItem.IconImageSource = "Logout.png";
            }
            else
            {
                _visibleService.VisibleOnDisconnect();
                MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
                menuItem.IsEnabled = false;
                menuItem.Text = "";
                menuItem.IconImageSource = "";
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
