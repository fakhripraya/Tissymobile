using EsrivaMobile.Helpers;
using EsrivaMobile.Models;
using EsrivaMobile.Views;
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
    public class FilesApiServices
    {
        public async Task<(bool, string)> UploadProfilePictureAsync(HttpContent content)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",Settings.AccessToken);

            var response = await httpClient.PostAsync($"http://{Settings.APILink}/api/Files/UploadPFP", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }
    }
}
