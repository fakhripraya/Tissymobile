using EsrivaMobile.Services;
using EsrivaMobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
        private ActivityIndicatorPopUpPage LoadingSplash = new ActivityIndicatorPopUpPage();
        private FilesApiServices filesApiServices = new FilesApiServices();
        private MediaFile mediaFile;
        private string fromPage;
        public ImagePickerPopUpPage(string fromPage)
        {
            InitializeComponent();
            this.fromPage = fromPage;
        }

        public event EventHandler<EventArgs> OperationCompleted;

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
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

                await PopupNavigation.Instance.PushAsync(LoadingSplash);

                if (fromPage == "EDIT")
                {

                }
                else
                {
                    var content = new MultipartFormDataContent();

                    content.Add(new StreamContent(mediaFile.GetStream()),
                        "\"file\"",
                        $"\"{mediaFile.Path}\"");

                    var result = await filesApiServices.UploadProfilePictureAsync(content);
                    OperationCompleted?.Invoke(this, EventArgs.Empty);
                    await PopupNavigation.Instance.PopAllAsync();
                }
            });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}