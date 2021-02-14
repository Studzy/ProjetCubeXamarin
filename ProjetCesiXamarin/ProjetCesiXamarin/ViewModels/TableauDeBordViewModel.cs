using GalaSoft.MvvmLight;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetCesiXamarin.ViewModels
{
    public class TableauDeBordViewModel : ViewModelBase
    {
        public TableauDeBordViewModel()
        {

        }

        private string _nomVue;

        public string NomVue
        {
            get { return _nomVue; }
            set
            {
                _nomVue = value;
                RaisePropertyChanged();
            }
        }

        private string _tri;

        public string Tri
        {
            get { return _tri; }
            set
            {
                _tri = value;
                RaisePropertyChanged();
            }
        }

        private string _recherche;

        public string Recherche
        {
            get { return _recherche; }
            set
            {
                _recherche = value;
                RaisePropertyChanged();
            }
        }

        private int _page;

        public int Page
        {
            get { return _page; }
            set
            {
                _page = value;
                RaisePropertyChanged();
            }
        }

        private int _nombrePages;

        public int NombrePages
        {
            get { return _nombrePages; }
            set
            {
                _nombrePages = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RessourceData> _ressources;
        public ObservableCollection<RessourceData> Ressources
        {
            get { return _ressources; }
            set
            {
                _ressources = value;
                RaisePropertyChanged();
            }
        }
    }
}
