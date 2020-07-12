using EsrivaMobile.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsrivaMobile.Views.PopUpViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePickerPopUpPage : PopupPage
    {
        private FilesApiServices filesApiServices;
        private MediaFile mediaFile;
        private ImageSource imageSource;
        private string fromPage;
        public ImagePickerPopUpPage(string fromPage)
        {
            InitializeComponent();
            this.fromPage = fromPage;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No PickPhoto", "No PickPhoto available", "OK");
                return;
            }

            mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (mediaFile == null)
                return;

            imageSource = ImageSource.FromStream(() =>
            {
                return mediaFile.GetStream();
            });

            if (fromPage == "EDIT")
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new ProfileEditPage(imageSource));
            }
            else
            {
                var content = new MultipartFormDataContent();

                content.Add(new StreamContent(mediaFile.GetStream()),
                    "\"file\"",
                    $"\"{mediaFile.Path}\"");

                var result = await filesApiServices.UploadProfilePictureAsync(content);

                await Application.Current.MainPage.Navigation.PushModalAsync(new ProfilePage(imageSource));

            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}