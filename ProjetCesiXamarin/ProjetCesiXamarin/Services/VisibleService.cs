using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetCesiXamarin.Services
{
    public class VisibleService : BaseService
    {
        /// <summary>
        /// Afffiche les tabs quand on est connecter
        /// </summary>
        public void VisibleOnConnect()
        {
            Tab resultTab = Shell.Current.FindByName<Tab>("Profil");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Creation");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Accueil");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Consultation");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Board");
            resultTab.IsVisible = true;
            //resultTab = Shell.Current.FindByName<Tab>("Deconnection");
            //resultTab.IsVisible = true;
            //MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
            //menuItem.IsEnabled = true;
            resultTab = Shell.Current.FindByName<Tab>("Connection");
            resultTab.IsVisible = false;
            resultTab = Shell.Current.FindByName<Tab>("Inscription");
            resultTab.IsVisible = false;
        }

        /// <summary>
        /// Affiche les tabs quand on est deconnecter
        /// </summary>
        public void VisibleOnDisconnect()
        {
            Tab resultTab = Shell.Current.FindByName<Tab>("Profil");
            resultTab.IsVisible = false;
            resultTab = Shell.Current.FindByName<Tab>("Creation");
            resultTab.IsVisible = false;
            resultTab = Shell.Current.FindByName<Tab>("Board");
            resultTab.IsVisible = false;
            resultTab = Shell.Current.FindByName<Tab>("Accueil");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Consultation");
            resultTab.IsVisible = true;
            //MenuItem menuItem = Shell.Current.FindByName<MenuItem>("Deconnection");
            //menuItem.IsEnabled = false;
            resultTab = Shell.Current.FindByName<Tab>("Connection");
            resultTab.IsVisible = true;
            resultTab = Shell.Current.FindByName<Tab>("Inscription");
            resultTab.IsVisible = true;
        }
    }
}
