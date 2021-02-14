using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConsultationViewModel : ViewModelBase
    {
        private string _textsearch;
        ConsultationService _consultationService = new ConsultationService();
        public ICommand RechercheCommand;

        public ConsultationViewModel()
        {
            //Task.Run(new Func<Task>(() => Search()));
            RechercheCommand = new RelayCommand<string>((query) => Search(query));
        }

        public string Textsearch
        {
            get { return _textsearch; }
            set
            {
                _textsearch = value;
                RaisePropertyChanged();
            }
        }

        public void Search(string query)
        {
            RechercheRessource recherche = new RechercheRessource();
            if (!string.IsNullOrWhiteSpace(Textsearch))
            {
                recherche.Recherche = Textsearch;
                //var SearchResult = await _consultationService.GetSearch(Textsearch);
            }

            
        }


    }
}
