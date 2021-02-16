using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Constant;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Pages;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    public class InscriptionViewModel : ViewModelBase
    {
        RegisterServices _registerService = new RegisterServices();

        public ICommand RegisterUserCommand { get; set; }

        public InscriptionViewModel()
        {
            RegisterUserCommand = new RelayCommand(() => RegisterUser());
        }
        /// <summary>
        /// Inscription
        /// </summary>
        async void RegisterUser()
        {
            RegisterData registerData = new RegisterData();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(PasswordConfirm))
                {
                    registerData.Username = Username;
                    registerData.Email = Email;
                    registerData.Password = Password;
                    registerData.ConfirmPassword = PasswordConfirm;

                    var ResultRegister = await _registerService.Register("api/AccountAPI/Register", registerData);

                    if (ResultRegister.Item1)
                    {
                        await Shell.Current.GoToAsync("//Connection");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erreur", ResultRegister.Item2, "Ok");
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

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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

        private string _passwordConfirm;

        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                RaisePropertyChanged();
            }
        }

    }
}
