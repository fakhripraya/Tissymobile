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
    public partial class ProfileEditPage : ContentPage
    {
        private ImageSource pfpImageSource;
        public ProfileEditPage(ImageSource pfpImageSource)
        {
            InitializeComponent();
            this.pfpImageSource = pfpImageSource;
        }
    }
}