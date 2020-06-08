using ScoringSystem.Mobile.Models;
using ScoringSystem.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoringSystem.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Login Login { get; set; }
        public INavigation Navigation { get; set; }

        public LoginViewModel()
        {
            Login = new Login();
        }

        public Login LoginObject
        {
            get => Login;
            set
            {
                Login = value; OnPropertyChanged();
            }
        }

        Command _saveCommandProp;

        public Command LoginCommand => _saveCommandProp ?? (_saveCommandProp = new Command(async () => await ExecuteOnLogin()));

        private async Task ExecuteOnLogin()
        {
            var loginData = LoginObject;

            var result = await DataStore.Login(loginData.Email, loginData.Password);

            await Navigation.PushModalAsync(new NavigationPage(new ItemsPage()));
        }
    }
}
