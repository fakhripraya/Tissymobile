using EsrivaMobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsrivaMobile.Services
{
    public class FilesApiServices
    {
        private string APILInk { get; set; } = "192.168.1.102:45459";

        public async Task<(bool, string)> UploadProfilePictureAsync(HttpContent content)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync($"http://{APILInk}/api/Files/Upload", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }
    }
}
