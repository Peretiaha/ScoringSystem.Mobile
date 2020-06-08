using ScoringSystem.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ScoringSystem.Mobile.Services;

namespace ScoringSystem.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel LoginViewModel { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            LoginViewModel = new LoginViewModel { Navigation = Navigation };
            BindingContext = LoginViewModel;
        }
    }
}