using EsrivaMobile.Helpers;
using EsrivaMobile.Services;
using EsrivaMobile.Views.PopUpViews;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsrivaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailVerificationPage : ContentPage
    {
        private ActivityIndicatorPopUpPage LoadingSplash = new ActivityIndicatorPopUpPage();
        private Random OtpGenerator = new Random();
        private ApiServices ApiServices = new ApiServices();
        private string RecentOTP { get; set; }
        private string OTPCode { get; set; }
        public string InputOTP { get; set; }

        public string TargetEmail;
        public string TargetPassword;
        public string headerText { get; set; }
        public string bodyText { get; set; }
        public EmailVerificationPage(string TargetEmail , string TargetPassword)
        {
            InitializeComponent();
            this.TargetEmail = TargetEmail;
            this.TargetPassword = TargetPassword;
            OTPCode = OtpGenerator.Next(0, 999999).ToString("D6");
            EmailVerif();
            headerText = $"Kami telah mengirimkan sebuah email ke\n{this.TargetEmail}";
            bodyText = "Anda harus menginput kode OTP\n" +
                "yang telah kami kirim ke email diatas\n" +
                "jika anda tidak mendapatkan email apapun dari kami,\n" +
                "dimohon untuk memeriksa email\n" +
                "di bagian \"Spam\" atau folder \"Bulk Email\"\n" +
                "anda juga bisa menekan tombol \"Resend\" dibawah\n" +
                "jika anda tidak mendapatkan email apapun dari kami";
            RecentOTP = OTPCode;
            BindingContext = this;
        }

        private void EmailVerif()
        {
            Task.Run(async ()=>
            {
                await ApiServices.sendEmailVerificationAsync(TargetEmail, OTPCode);
            });
        }

        public ICommand ResendEmailCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(LoadingSplash);
                    OTPCode = OtpGenerator.Next(0, 999999).ToString("D6");
                    var isSuccess = await ApiServices
                        .sendEmailVerificationAsync(TargetEmail , OTPCode);

                    if (isSuccess.Item1)
                    {
                        RecentOTP = OTPCode;
                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.DisplayAlert("Email Berhasil Terkirim Ulang", "Silahkan cek kembali email anda", "OK");
                    }
                    else
                    {
                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.DisplayAlert("Gagal Mengirim Ulang Email", isSuccess.Item2, "OK");
                    }
                });
            }
        }

        public ICommand VerifyOTPCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.Instance.PushAsync(LoadingSplash);
                    if (InputOTP == RecentOTP)
                    {
                        var isSuccess = await ApiServices
                        .OTPVerification(TargetEmail);

                        if (isSuccess.Item1)
                        {
                            var loginResult = await ApiServices
                                .LoginAsync(TargetEmail, TargetPassword);

                            if (loginResult.Item1 == null)
                            {
                                await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                                await Application.Current.MainPage.DisplayAlert("Gagal Verifikasi", "Error 404", "OK");
                            }
                            else
                            {
                                Settings.Email = TargetEmail;
                                Settings.Password = TargetPassword;
                                Settings.AccessToken = loginResult.Item1;
                                Settings.TokenExpired = loginResult.Item2;
                                Settings.TokenIssued = loginResult.Item3;
                                var userInfo = await ApiServices.getUserInfoAsync();
                                Settings.UserId = userInfo.UserId;


                                await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                                Application.Current.MainPage = new AppShell();
                                await Shell.Current.GoToAsync("//main");
                                await Application.Current.MainPage.DisplayAlert("Berhasil Verifikasi Email", "Anda akan dipindahkan ke dashboard", "OK");
                            }
                        }
                        else
                        {
                            await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                            await Application.Current.MainPage.DisplayAlert("Gagal Verifikasi", isSuccess.Item2, "OK");
                        }
                    }
                    else
                    {
                        await PopupNavigation.Instance.RemovePageAsync(LoadingSplash);
                        await Application.Current.MainPage.DisplayAlert("Gagal Verifikasi", "Kode OTP tidak sesuai", "OK");
                    }
                });
            }
        }
    }
}