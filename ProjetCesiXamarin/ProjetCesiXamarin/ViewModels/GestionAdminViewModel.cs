using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class GestionAdminViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand NavigateToListUserCommand { get; set; }

        public GestionAdminViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToListUserCommand = new RelayCommand(() => NavigateToListUser());
            
        }

        public async void NavigateToListUser()
        {
            // _navigationService.NavigateTo("ListUser");
            await Shell.Current.GoToAsync("//ListUser");
        }
    }
}
