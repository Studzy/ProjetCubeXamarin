using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConsultationViewModel : ViewModelBase
    {
        private string _textsearch;
        ConsultationService _consultationService = new ConsultationService();
        //public ICommand RechercheCommand;

        //public ConsultationViewModel()
        //{
        //    RechercheCommand = new RelayCommand<string>((query) => Search(query));
        //}

        public ICommand RechercheCommand => new RelayCommand<string>((Textsearch) => Search(Textsearch));

        public string Textsearch
        {
            get { return _textsearch; }
            set
            {
                _textsearch = value;
                RaisePropertyChanged();
            }
        }

        public void Search(string Textsearch)
        {
            RechercheRessource recherche = new RechercheRessource();
            if (!string.IsNullOrWhiteSpace(Textsearch))
            {
                recherche.Recherche = Textsearch;
            }
        }



        public ICommand PerformSearch => new RelayCommand<string>((query) => Rechercher(query));

        public void Rechercher(string query)
        {

        }
    }
}
