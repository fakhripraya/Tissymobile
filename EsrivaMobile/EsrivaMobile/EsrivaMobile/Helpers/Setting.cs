using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EsrivaMobile.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault("Email", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Email", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string TokenExpired
        {
            get
            {
                return AppSettings.GetValueOrDefault("TokenExpired", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TokenExpired", value);
            }
        }

        public static string TokenIssued
        {
            get
            {
                return AppSettings.GetValueOrDefault("TokenIssued", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TokenIssued", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserId", value);
            }
        }

        public static string APILink
        {
            get
            {
                return AppSettings.GetValueOrDefault("APILink", "192.168.1.101:45455");
            }
        }
    }
}