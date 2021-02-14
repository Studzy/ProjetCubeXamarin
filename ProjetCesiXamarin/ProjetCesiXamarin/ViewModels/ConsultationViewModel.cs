using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjetCesiXamarin.ViewModels
{
    public class ConsultationViewModel : ViewModelBase
    {
        public ICommand PerformSearch => new RelayCommand<string>((query) => Rechercher(query));

        public void Rechercher(string query)
        {

        }
    }
}
