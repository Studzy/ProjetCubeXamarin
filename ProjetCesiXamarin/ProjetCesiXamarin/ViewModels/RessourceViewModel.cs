using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ObservableCollection<TypeRelationData> _typeRelations;
        public bool _isUserConnected;
        private string _ressourceId;

        public string RessourceId
        {
            get => _ressourceId;
            set
            {
                _ressourceId = value;

                Task.Run(new Func<Task>(async () =>
                {
                    var ressourceComplete = await new RessourceServices().GetRessourceByIdAsync(int.Parse(_ressourceId));

                    Ressource = ressourceComplete;
                    Categorie = ressourceComplete.Categorie.Nom;
                    TypeRessource = ressourceComplete.TypeRessource.Nom;
                    TypeRelations = new ObservableCollection<TypeRelationData>(ressourceComplete.TypeRelations);
                }));

                RaisePropertyChanged();
            }
        }

        public RessourceViewModel()
        {
            Task.Factory.StartNew(new Func<Task>(async () => await CheckUserIsConnected())).Unwrap().Wait();
        }

        private async Task CheckUserIsConnected()
        {
            if (await SecureStorage.GetAsync("token") != null && await SecureStorage.GetAsync("user") != null)
            {
                IsUserConnected = true;
            }
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

        public ObservableCollection<TypeRelationData> TypeRelations
        {
            get { return _typeRelations; }
            set
            {
                _typeRelations = value;
                RaisePropertyChanged();
            }
        }
    }
}
