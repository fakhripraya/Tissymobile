using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EsrivaMobile.Services;
using EsrivaMobile.Views;
using EsrivaMobile.Helpers;

namespace EsrivaMobile
{
    public partial class App : Application
    {
        private ApiServices apiService = new ApiServices();
        public App()
        {
            InitializeComponent();
            setMainPage();
        }

        private void setMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                //TODO: Token Expiracy Control Test
                if (Convert.ToDateTime(Settings.TokenExpired) == DateTime.Now)
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
                else
                {
                    MainPage = new AppShell();
                }
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
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
