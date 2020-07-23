using EsrivaMobile.Helpers;
using EsrivaMobile.Models;
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
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private UserAPIService userAPIService = new UserAPIService();

        // User Model
        private LoggedUserModel _user;
        public LoggedUserModel User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); } 
        }

        // Profile Page Property
        private static ImageSource _ProfilePictureSource;
        public ImageSource ProfilePictureSource
        {
            get { return _ProfilePictureSource; }
            set { _ProfilePictureSource = value; OnPropertyChanged(); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }
        private string _userRank;
        public string UserRank
        {
            get { return _userRank; }
            set { _userRank = value; OnPropertyChanged(); }
        }
        private string _userLocation;
        public string UserLocation
        {
            get { return _userLocation; }
            set { _userLocation = value; OnPropertyChanged(); }
        }
        private bool _userLocationVisibility;
        public bool UserLocationVisibility
        {
            get { return _userLocationVisibility; }
            set { _userLocationVisibility = value; OnPropertyChanged(); }
        }
        private string _userAbout;
        public string UserAbout
        {
            get { return _userAbout; }
            set { _userAbout = value; OnPropertyChanged(); }
        }
        private string _userPodcastCount;
        public string UserPodcastCount
        {
            get { return _userPodcastCount; }
            set { _userPodcastCount = value; OnPropertyChanged(); }
        }
        private string _userFollowingCount;
        public string UserFollowingCount
        {
            get { return _userFollowingCount; }
            set { _userFollowingCount = value; OnPropertyChanged(); }
        }
        private string _userFollowersCount;
        public string UserFollowersCount
        {
            get { return _userFollowersCount; }
            set { _userFollowersCount = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProfileViewModel()
        {
            getProfile();
        }

        private void getProfile()
        {
            Task.Run(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new ActivityIndicatorPopUpPage());
                User = await userAPIService.GetUserProfileAsync();
                ProfilePictureSource = User.ProfilePictureSource;
                UserName = User.UserName;
                UserRank =  "( " + User.Rank + " )";
                UserLocation = User.Location;
                if (UserLocation.ToUpper() == "UNKNOWN")
                {
                    UserLocationVisibility = false;
                }
                else
                {
                    UserLocationVisibility = true;
                }
                UserAbout = User.About;
                UserPodcastCount = User.PodcastCount;
                UserFollowersCount = User.FollowersCount;
                UserFollowingCount = User.FollowingCount;
                await PopupNavigation.Instance.PopAllAsync();
            });
        }

        public ICommand EditProfileCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProfileEditPage());
                });
            }
        }
    }
}
