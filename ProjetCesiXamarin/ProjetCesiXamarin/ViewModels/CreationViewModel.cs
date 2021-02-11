using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCesiXamarin.ViewModels
{
    class CreationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CreationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


    }
}
