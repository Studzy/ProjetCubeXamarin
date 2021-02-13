using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCesiXamarin.ViewModels
{
    class CreationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CreationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Task.Run(new Func<Task>(() => InitData()));
        }

        private async Task InitData()
        {
            CreationData data = await new CreationService().GetBaseInfo();
            Data = data;
            Categories = new ObservableCollection<CategorieData>(data.Categories);
            TypeRessources = new ObservableCollection<TypeRessourceData>(data.TypeRessources);
            TypeRelations = new ObservableCollection<TypeRelationData>(data.TypeRelations);
        }

        private CreationData _data;
        public CreationData Data 
        {
            get { return _data; }
            set
            {
                _data = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<CategorieData> _categories;
        public ObservableCollection<CategorieData> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<TypeRelationData> _typeRelations;
        public ObservableCollection<TypeRelationData> TypeRelations
        {
            get { return _typeRelations; }
            set
            {
                _typeRelations = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<TypeRessourceData> _typeRessources;
        public ObservableCollection<TypeRessourceData> TypeRessources
        {
            get { return _typeRessources; }
            set
            {
                _typeRessources = value;
                RaisePropertyChanged();
            }
        }

    }
}
