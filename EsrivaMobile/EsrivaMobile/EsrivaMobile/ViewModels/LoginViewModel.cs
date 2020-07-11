using EsrivaMobile.Helpers;
using EsrivaMobile.Services;
using EsrivaMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EsrivaMobile.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices ApiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ResponseMessage { get; set; }
        public ICommand NavigateCommand => new Command(Navigate);
        private async void Navigate()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accountStatus = await ApiServices
                    .CheckVerification(Email);

                    if (!accountStatus.Item1)
                    {
                        Settings.Email = Email;
                        Settings.Password = Password;

                        await Application.Current.MainPage.Navigation.PushModalAsync(new EmailVerificationPage(Email, Password));
                    }
                    else
                    {
                        var accessToken = await ApiServices
                            .LoginAsync(Email, Password);

                        if (accessToken != null)
                        {
                            Settings.Email = Email;
                            Settings.Password = Password;
                            Settings.AccessToken = accessToken;

                            Application.Current.MainPage = new AppShell();

                            await Application.Current.MainPage.DisplayAlert("Login Success", "Welcome to your Dashboard!", "OK");

                            await Shell.Current.GoToAsync("//main");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Login Failed", "Input the correct information", "OK");
                        }
                    }
                });
            }
        }

        public LoginViewModel()
        {
            Email = Settings.Email;
            Password = Settings.Password;
        }
    }
}
