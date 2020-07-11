using EsrivaMobile.ViewModels;
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
    public partial class ForumPage : ContentPage
    {
        public ForumPage()
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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.Item == null) return;

            // Optionally pause a bit to allow the preselect hint.
            Task.Delay(500);

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}