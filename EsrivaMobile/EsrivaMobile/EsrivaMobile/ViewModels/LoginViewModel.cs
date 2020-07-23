using EsrivaMobile.Helpers;
using EsrivaMobile.Services;
using EsrivaMobile.Views;
using EsrivaMobile.Views.PopUpViews;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EsrivaMobile.ViewModels
{
    public class LoginViewModel
    {
        private ActivityIndicatorPopUpPage LoadingSplash = new ActivityIndicatorPopUpPage();

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
                    await PopupNavigation.Instance.PushAsync(LoadingSplash);

                    var accountStatus = await ApiServices
                    .CheckVerification(Email);

                    if (accountStatus.Item3 == "UserId not found.")
                    {
                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.DisplayAlert("Gagal Login", "User tidak ditemukan", "OK");
                    }
                    else if (!accountStatus.Item1)
                    {
                        Settings.Email = Email;
                        Settings.Password = Password;

                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EmailVerificationPage(Email, Password));
                    }
                    else
                    {
                        var loginResult = await ApiServices
                            .LoginAsync(Email, Password);

                        if (loginResult.Item1 != null)
                        {
                            Settings.Email = Email;
                            Settings.Password = Password;
                            Settings.AccessToken = loginResult.Item1;
                            Settings.TokenExpired = loginResult.Item2;
                            Settings.TokenIssued = loginResult.Item3;
                            var userInfo = await ApiServices.getUserInfoAsync();
                            Settings.UserId = userInfo.UserId;

                            await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                            Application.Current.MainPage = new AppShell();
                            await Shell.Current.GoToAsync("//main");
                            await Application.Current.MainPage.DisplayAlert("Berhasil Login", "Anda akan dipindahkan ke dashboard", "OK");
                        }
                        else
                        {
                            await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                            await Application.Current.MainPage.DisplayAlert("Gagal Login", "Silahkan input informasi dengan benar", "OK");
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
