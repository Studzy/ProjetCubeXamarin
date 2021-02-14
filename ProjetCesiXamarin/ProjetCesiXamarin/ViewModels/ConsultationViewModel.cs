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
        public ICommand PerformSearch => new RelayCommand<string>((query) => Rechercher(query));

        public void Rechercher(string query)
        {
                //recherche.Recherche = Textsearch;
                //var SearchResult = await _consultationService.GetSearch(Textsearch);
            


        }


    }
}
