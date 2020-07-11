using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsrivaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            InitializeComponent();
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
            Shell.SetTabBarIsVisible(this, true);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;

            await imageButton.ScaleTo(1.5, 50);
            await imageButton.ScaleTo(0.5, 100, Easing.BounceIn);
            await imageButton.ScaleTo(1, 100, Easing.BounceOut);
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}