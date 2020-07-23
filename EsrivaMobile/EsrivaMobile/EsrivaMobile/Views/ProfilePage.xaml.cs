using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using EsrivaMobile.Helpers;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using EsrivaMobile.Views.PopUpViews;
using EsrivaMobile.Services;
using System.IO;
using System.Net.Http;
using EsrivaMobile.ViewModels;

namespace EsrivaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        List<Entry> entriesPengunjung = new List<Entry>
        {
            new Entry(200)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Januari",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Februari",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Maret",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "April",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Mei",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Juni",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "400"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Juli",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Agustus",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "September",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "Oktober",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#1BBC9B"),
                Label = "November",
                TextColor = SKColor.Parse("#1BBC9B"),
                ValueLabel = "400"
            },
        };

        List<Entry> entriesForum = new List<Entry>
        {
            new Entry(200)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Januari",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Februari",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Maret",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "April",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Mei",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Juni",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "400"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Juli",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Agustus",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "September",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "Oktober",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#F24343"),
                Label = "November",
                TextColor = SKColor.Parse("#F24343"),
                ValueLabel = "400"
            },
        };

        List<Entry> entriesArtikel = new List<Entry>
        {
            new Entry(200)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "January",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "200"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Januari",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Februari",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Maret",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "April",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Mei",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Juni",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "400"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Juli",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Agustus",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "400"
            },

            new Entry(200)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "September",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "200"
            },

            new Entry(500)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "Oktober",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "500"
            },

            new Entry(400)
            {
                Color = SKColor.Parse("#4B64F2"),
                Label = "November",
                TextColor = SKColor.Parse("#4B64F2"),
                ValueLabel = "400"
            },
        };

        public ProfilePage()    
        {
            InitializeComponent();

            BindingContext = new ProfileViewModel();

            sPengunjung.Chart = new LineChart { Entries = entriesPengunjung };
            sForum.Chart = new LineChart { Entries = entriesForum };
            sArticle.Chart = new LineChart { Entries = entriesArtikel };

            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
            Shell.SetTabBarIsVisible(this, true);
        }

        private async void buttonAnimation(ImageButton sender)
        {
            var imageButton = sender;

            await imageButton.ScaleTo(1.5, 50);
            await imageButton.ScaleTo(0.5, 100, Easing.BounceIn);
            await imageButton.ScaleTo(1, 100, Easing.BounceOut);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            buttonAnimation(sender as ImageButton);
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            buttonAnimation(sender as ImageButton);
            bool answer = await DisplayAlert("Sign Out", "Would you like to Sign Out?", "Yes", "No");
            

            if (answer)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());

                Settings.AccessToken = "";
                await Application.Current.MainPage.DisplayAlert("Info", "Successfully Sign Out!", "OK");
            }
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                var pickerPage = new ImagePickerPopUpPage("NOEDIT");
                pickerPage.OperationCompleted += PickerPage_OperationCompleted;
                await PopupNavigation.Instance.PushAsync(pickerPage);
            });
        }

        private void PickerPage_OperationCompleted(object sender, EventArgs e)
        {
            (sender as ImagePickerPopUpPage).OperationCompleted -= PickerPage_OperationCompleted;

            BindingContext = new ProfileViewModel();
        }
    }
}