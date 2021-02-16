using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetCesiXamarin.ViewModels
{
    public class ProfilViewModel : ViewModelBase
    {
        private UserData _user;

        public ProfilViewModel()
        {
            Task.Run(new Func<Task>(() => InitProfil()));
        }

        public async Task InitProfil()
        {
            string UserSerialize = await SecureStorage.GetAsync("user");
            User = JsonConvert.DeserializeObject<UserData>(UserSerialize);
        }

        public UserData User
        {
            get { return _user; }
            set
            {
                _user = value;

                RaisePropertyChanged();
            }
        }
    }
}
