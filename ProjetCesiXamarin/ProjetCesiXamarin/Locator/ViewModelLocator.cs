using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using ProjetCesiXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCesiXamarin.Locator
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<InscriptionViewModel>();
            SimpleIoc.Default.Register<ConnectionViewModel>();
            SimpleIoc.Default.Register<AccueilViewModel>();
            SimpleIoc.Default.Register<RessourceViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        public InscriptionViewModel InscriptionViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InscriptionViewModel>();
            }
        }

        public ConnectionViewModel ConnectionViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConnectionViewModel>();
            }
        }

        public AccueilViewModel AccueilViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccueilViewModel>();
            }
        }

        public RessourceViewModel RessourceViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RessourceViewModel>();
            }
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public GestionAdminViewModel GestionAdminViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GestionAdminViewModel>();
            }
        }
    }
}
