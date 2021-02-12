using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
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

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Task.Factory.StartNew(new Func<Task>(async () => await InitData())).Unwrap().Wait();
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
                    }
                    else
                    {
                        UserName = username;
                    }
                }
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
