using EsrivaMobile.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EsrivaMobile.Models
{
    public class LoggedUserModel : BaseModel
    {
        private ImageSource _profilePictureSource;
        public ImageSource ProfilePictureSource
        {
            get => _profilePictureSource;
            set => SetProperty(ref _profilePictureSource, value);
        }
        private string _userId;
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _rank;
        public string Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }
        private string _location;
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }
        private string _about;
        public string About
        {
            get => _about;
            set => SetProperty(ref _about, value);
        }
        private string _podcastCount;
        public string PodcastCount
        {
            get => _podcastCount;
            set => SetProperty(ref _podcastCount, value);
        }
        private string _followingCount;
        public string FollowingCount
        {
            get => _followingCount;
            set => SetProperty(ref _followingCount, value);
        }
        private string _followersCount;
        public string FollowersCount
        {
            get => _followersCount;
            set => SetProperty(ref _followersCount, value);
        }
    }

    public class LoggedUserInfoModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class LoggedUserBindingModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rank { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public int PodcastCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
    }
}
