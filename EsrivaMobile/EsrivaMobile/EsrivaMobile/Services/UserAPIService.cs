using EsrivaMobile.Helpers;
using EsrivaMobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsrivaMobile.Services
{
    public class UserAPIService
    {
        public async Task<LoggedUserModel> GetUserProfileAsync()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            var UserSourceResponse = await httpClient.GetStringAsync($"http://{Settings.APILink}/api/User/GetUserInfo");
           
            var ImageSourceResponse = await httpClient.GetAsync($"http://{Settings.APILink}/api/User/GetPFP?guid={Settings.UserId}");

            var LoggedUserBinding = JsonConvert.DeserializeObject<LoggedUserBindingModel>(UserSourceResponse);

            Byte[] result = await ImageSourceResponse.Content.ReadAsByteArrayAsync();

            LoggedUserModel LoggedUser = new LoggedUserModel();

            LoggedUser.UserId = LoggedUserBinding.UserId;
            LoggedUser.ProfilePictureSource = ImageSource.FromStream(() => new MemoryStream(result));
            LoggedUser.UserName = LoggedUserBinding.Name;
            LoggedUser.Email = LoggedUserBinding.Email;
            LoggedUser.Rank = LoggedUserBinding.Rank;
            LoggedUser.Location = LoggedUserBinding.Location;
            LoggedUser.About = LoggedUserBinding.About;
            LoggedUser.PodcastCount = LoggedUserBinding.PodcastCount.ToString();
            LoggedUser.FollowersCount = LoggedUserBinding.FollowersCount.ToString();
            LoggedUser.FollowingCount = LoggedUserBinding.FollowingCount.ToString();

            return LoggedUser;
        }
    }
}
