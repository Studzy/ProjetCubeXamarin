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
        private readonly RessourceServices _ressourceServices;

        public RessourceData _ressource;
        private string _categorie;
        private string _typeRessource;
        private string _typeRelations;
        private string _badges;
        private string _commentaireEntry;
        private string _favorisText;
        private string _deCoteText;
        private string _exploiteText;
        private ObservableCollection<CommentaireData> _commentaires;
        public bool _isUserConnected;
        private string _ressourceId;
        bool _isRefreshing;
        bool isRefreshingInterne = false;

        public ICommand RefreshCommand { get; set; }
        public ICommand FavorisCommand { get; set; }
        public ICommand ExploiteCommand { get; set; }
        public ICommand DeCoteCommand { get; set; }
        public ICommand SendCommentaireCommand { get; set; }

        public string RessourceId
        {
            get => _ressourceId;
            set
            {
                if (value != _ressourceId)
                {
                    _ressourceId = value;
                    Task.Run(new Func<Task>(async () => await RefreshView()));
                }
                else
                {
                    Task.Run(() => CheckUserIsConnected());
                }
            }
        }

        
        public RessourceViewModel()
        {
            _ressourceServices = new RessourceServices();
            RefreshCommand = new RelayCommand(async () => await RefreshView());
            FavorisCommand = new RelayCommand(async () => await GestionFavoris());
            ExploiteCommand = new RelayCommand(async () => await GestionExploite());
            DeCoteCommand = new RelayCommand(async () => await GestionDeCote());
            SendCommentaireCommand = new RelayCommand(async () => await SendCommentaire());
        }

        private async Task GestionFavoris()
        {
            Ressource.EstFavoris = !Ressource.EstFavoris;

            if (Ressource.EstFavoris)
            {
                if (await _ressourceServices.AjouterFavoris(int.Parse(RessourceId)))
                    FavorisText = "Supprimer des favoris";
            }
            else
            {
                if (await _ressourceServices.SupprimerFavoris(int.Parse(RessourceId)))
                    FavorisText = "Ajouter à mes favoris";
            }
        }

        private async Task GestionExploite()
        {
            Ressource.EstExploite = !Ressource.EstExploite;

            if (Ressource.EstExploite)
            {
                if (await _ressourceServices.AjouterExploite(int.Parse(RessourceId)))
                    ExploiteText = "Supprimer des ressources exploitées";
            }
            else
            {
                if (await _ressourceServices.SupprimerExploite(int.Parse(RessourceId)))
                    ExploiteText = "Indiquer comme exploitée";
            }
        }

        private async Task GestionDeCote()
        {
            Ressource.EstMisDeCote = !Ressource.EstMisDeCote;

            if (Ressource.EstMisDeCote)
            {
                if (await _ressourceServices.AjouterMettreDeCote(int.Parse(RessourceId)))
                    DeCoteText = "Supprimer des ressources mises de côtés";
            }
            else
            {
                if (await _ressourceServices.SupprimerMettreDeCote(int.Parse(RessourceId)))
                    DeCoteText = "Mettre de côté";
            }
        }

        private async Task SendCommentaire()
        {
            var comm = new { contenu = CommentaireEntry, ressourceId = RessourceId };

            var comms = await _ressourceServices.PosterCommentaire(comm);

            if (comms != null)
            {
                Commentaires = new ObservableCollection<CommentaireData>(comms.Commentaires);
            }

            CommentaireEntry = string.Empty;
        }


        private async Task CheckUserIsConnected()
        {
            if (await SecureStorage.GetAsync("token") != null && await SecureStorage.GetAsync("user") != null)
            {
                IsUserConnected = true;
            }
            else
            {
                IsUserConnected = false;
            }
        }

        private async Task RefreshView()
        {
            if (!isRefreshingInterne)
            {
                IsRefreshing = true;
                isRefreshingInterne = true;

                var ressourceComplete = await new RessourceServices().GetRessourceByIdAsync(int.Parse(_ressourceId));
                await CheckUserIsConnected();

                Ressource = ressourceComplete;
                Categorie = ressourceComplete.Categorie.Nom;
                TypeRessource = ressourceComplete.TypeRessource.Nom;
                TypeRelations = ressourceComplete.TypeRelationsString;
                Commentaires = new ObservableCollection<CommentaireData>(ressourceComplete.Commentaires);

                Badges = $"{Categorie}<br />{TypeRessource}<br />{TypeRelations}";

                if (_ressource.EstFavoris)
                    FavorisText = "Supprimer des favoris";
                else
                    FavorisText = "Ajouter à mes favoris";

                if (_ressource.EstMisDeCote)
                    DeCoteText = "Supprimer des ressources mises de côtés";
                else
                    DeCoteText = "Mettre de côté";

                if (_ressource.EstExploite)
                    ExploiteText = "Supprimer des ressources exploitées";
                else
                    ExploiteText = "Indiquer comme exploitée";

                IsRefreshing = false;
                isRefreshingInterne = false;
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

        public string CommentaireEntry
        {
            get { return _commentaireEntry; }
            set
            {
                _commentaireEntry = value;
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

        public string FavorisText 
        {
            get { return _favorisText; }
            set
            {
                _favorisText = value;
                RaisePropertyChanged();
            }
        }

        public string DeCoteText
        {
            get { return _deCoteText; }
            set
            {
                _deCoteText = value;
                RaisePropertyChanged();
            }
        }

        public string ExploiteText
        {
            get { return _exploiteText; }
            set
            {
                _exploiteText = value;
                RaisePropertyChanged();
            }
        }
    }
}
