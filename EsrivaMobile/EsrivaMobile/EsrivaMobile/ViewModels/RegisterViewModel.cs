using EsrivaMobile.Helpers;
using EsrivaMobile.Services;
using EsrivaMobile.Views;
using EsrivaMobile.Views.PopUpViews;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EsrivaMobile.ViewModels
{
    public class RegisterViewModel
    {
        private ActivityIndicatorPopUpPage LoadingSplash = new ActivityIndicatorPopUpPage();
        private ApiServices ApiServices = new ApiServices();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ResponseMessage { get; set; }
        public ICommand NavigateCommand => new Command(Navigate);
        private async void Navigate()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(LoadingSplash);
                    var isSuccess = await ApiServices
                        .RegisterAsync(Name, Email, Password, ConfirmPassword);

                    if (isSuccess.Item1)
                    {
                        Settings.Email = Email;
                        Settings.Password = Password;

                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EmailVerificationPage(Email,Password));
                    }
                    else
                    {
                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.DisplayAlert("Gagal Melakukan Registrasi", isSuccess.Item2, "OK");
                    }
                });
            }
        }
    }
}
