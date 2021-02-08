using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjetCesiXamarin.Locator;
using ProjetCesiXamarin.Pages;
using ProjetCesiXamarin.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetCesiXamarin
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
        public App()
        {
            InitializeComponent();

            NavigationService navigationService = new NavigationService();

            navigationService.Configure("Inscription", typeof(Connection));
            navigationService.Configure("Home", typeof(Inscription));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            var firstPage = new NavigationPage(new Inscription());
            navigationService.Initialize(firstPage);
            MainPage = firstPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
