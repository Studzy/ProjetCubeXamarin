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
    public partial class Connection : ContentPage
    {
        public Connection()
        {
            InitializeComponent();
            BindingContext = App.Locator.ConnectionViewModel;
        }
    }
}