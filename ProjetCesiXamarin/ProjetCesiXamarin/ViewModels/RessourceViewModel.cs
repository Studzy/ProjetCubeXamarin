using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetCesiXamarin.ViewModels
{
    [QueryProperty(nameof(RessourceId), nameof(RessourceId))]
    public class RessourceViewModel : ViewModelBase
    {
        public RessourceData _ressource;
        private string _categorie;
        private string _typeRessource;
        private string _typeRelations;
        private string _badges;
        private ObservableCollection<CommentaireData> _commentaires;
        public bool _isUserConnected;
        private string _ressourceId;
        bool _isRefreshing;

        public ICommand RefreshCommand { get; set; }

        public string RessourceId
        {
            get => _ressourceId;
            set
            {
                _ressourceId = value;

                Task.Run(new Func<Task>(() => RefreshView()));

                RaisePropertyChanged();
            }
        }

        public RessourceViewModel()
        {
            RefreshCommand = new RelayCommand(async () => await RefreshView());
            Task.Factory.StartNew(new Func<Task>(async () => await CheckUserIsConnected())).Unwrap().Wait();
        }

        private async Task CheckUserIsConnected()
        {
            if (await SecureStorage.GetAsync("token") != null && await SecureStorage.GetAsync("user") != null)
            {
                IsUserConnected = true;
            }
        }

        private async Task RefreshView()
        {
            IsRefreshing = true;

            var ressourceComplete = await new RessourceServices().GetRessourceByIdAsync(int.Parse(_ressourceId));

            Ressource = ressourceComplete;
            Categorie = ressourceComplete.Categorie.Nom;
            TypeRessource = ressourceComplete.TypeRessource.Nom;
            TypeRelations = ressourceComplete.TypeRelationsString;
            Commentaires = new ObservableCollection<CommentaireData>(ressourceComplete.Commentaires);

            Badges = $"{Categorie}<br />{TypeRessource}<br />{TypeRelations}";

            IsRefreshing = false;
        }

        public RessourceData Ressource
        {
            get { return _ressource; }
            set
            {
                _ressource = value;
                RaisePropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged();
            }
        }

        public bool IsUserConnected
        {
            get { return _isUserConnected; }
            set
            {
                _isUserConnected = value;
                RaisePropertyChanged();
            }
        }

        public string Categorie
        {
            get { return _categorie; }
            set
            {
                _categorie = value;
                RaisePropertyChanged();
            }
        }

        public string TypeRessource
        {
            get { return _typeRessource; }
            set
            {
                _typeRessource = value;
                RaisePropertyChanged();
            }
        }

        public string Badges
        {
            get { return _badges; }
            set
            {
                _badges = value;
                RaisePropertyChanged();
            }
        }

        public string TypeRelations
        {
            get { return _typeRelations; }
            set
            {
                _typeRelations = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CommentaireData> Commentaires
        {
            get { return _commentaires; }
            set
            {
                _commentaires = value;
                RaisePropertyChanged();
            }
        }
    }
}
