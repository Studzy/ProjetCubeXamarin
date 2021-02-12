﻿using ProjetCesiXamarin.Models;
using ProjetCesiXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetCesiXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ressource : ContentPage
    {
        public Ressource()
        {
            InitializeComponent();
            BindingContext = new RessourceViewModel();
        }
    }
}