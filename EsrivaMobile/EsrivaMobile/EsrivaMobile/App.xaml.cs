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

        public App()
        {
            InitializeComponent();
            setMainPage();
        }

        private void setMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new AppShell();
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
