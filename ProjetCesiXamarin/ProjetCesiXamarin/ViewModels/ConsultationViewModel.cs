using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        
        ConsultationService _consultationService = new ConsultationService();

        public ICommand RechercheCommand => new RelayCommand<string>(async(query) => await Search(query));

        private string _query;
        public string query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChanged();
            }
        }

        public async Task Search(string query)
        {
            RechercheRessource recherche = new RechercheRessource();
            if (!string.IsNullOrWhiteSpace(query))
            {
                recherche.Recherche = query;
                var searchResult = await _consultationService.GetSearch(query);
            }
        }

        public ObservableCollection<RechercheRessource> _recherche;

        public ObservableCollection<RechercheRessource> Recherche
        {
            get { return _recherche;}
            set
            {
                _recherche = value;
                RaisePropertyChanged();
            }
        }

    }
}
