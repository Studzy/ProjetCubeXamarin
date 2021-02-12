using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    [QueryProperty(nameof(Ressource), nameof(Ressource))]
    public class RessourceViewModel : BindableObject
    {
        public RessourceData _ressource;
        public RessourceViewModel()
        {

        }
        public RessourceData Ressource
        {
            get { return _ressource; }
            set
            {

                _ressource = value;
                //RaisePropertyChanged();
                OnPropertyChanged("Ressource");
            }
        }

    }
}
