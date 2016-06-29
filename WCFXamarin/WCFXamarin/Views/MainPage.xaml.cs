using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFXamarin.ViewModel;
using Xamarin.Forms;

namespace WCFXamarin.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainPageViewModel viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
    }
}
