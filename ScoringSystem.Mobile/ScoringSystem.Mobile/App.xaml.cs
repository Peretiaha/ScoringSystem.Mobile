using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScoringSystem.Mobile.Services;
using ScoringSystem.Mobile.Views;
using Xamarin.Essentials;

namespace ScoringSystem.Mobile
{
    public partial class App : Application
    {

        public static string ApiURL =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://fc86de9ba843.ngrok.io/api/" : "https://fc86de9ba843.ngrok.io/api/";
        public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
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
