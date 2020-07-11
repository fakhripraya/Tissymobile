using EsrivaMobile.Helpers;
using EsrivaMobile.Services;
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
            ApiServices.sendEmailVerificationAsync(TargetEmail, OTPCode);
            headerText = $"We have sent an OTP code to\n{this.TargetEmail}";
            bodyText = "Your need to input the OTP code to continue\n" +
                "if you have not received the OTP verification email,\n" +
                "please check your \"Spam\" or \"Bulk Email\" folder\n" +
                "You can also click the resend button below to have\n" +
                "another email sent to you";
            RecentOTP = OTPCode;
            BindingContext = this;
        }
        public ICommand ResendEmailCommand
        {
            get
            {
                return new Command(async () =>
                {
                    OTPCode = OtpGenerator.Next(0, 999999).ToString("D6");
                    var isSuccess = await ApiServices
                        .sendEmailVerificationAsync(TargetEmail , OTPCode);

                    if (isSuccess.Item1)
                    {
                        await Application.Current.MainPage.DisplayAlert("Successfully resend email", "Please kindly check your email again", "OK");
                        RecentOTP = OTPCode;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Resend fail", isSuccess.Item2, "OK");
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
                    if (InputOTP == RecentOTP)
                    {
                        var isSuccess = await ApiServices
                        .OTPVerification(TargetEmail);

                        if (isSuccess.Item1)
                        {
                            var accessToken = await ApiServices
                                .LoginAsync(TargetEmail, TargetPassword);

                            if (accessToken == null)
                            {
                                await Application.Current.MainPage.DisplayAlert("Verification Failed", "Error 404", "OK");
                            }
                            else
                            {
                                Settings.Email = TargetEmail;
                                Settings.Password = TargetPassword;
                                Settings.AccessToken = accessToken;

                                await Application.Current.MainPage.DisplayAlert("Successfully verify email", "We will send you to your dashboard", "OK");

                                Application.Current.MainPage = new AppShell();

                                await Shell.Current.GoToAsync("//main");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Verification Failed", isSuccess.Item2, "OK");
                        }
                    }
                });
            }
        }
    }
}