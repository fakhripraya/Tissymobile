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
    public class ApiServices
    {
        public async Task<(bool,string)> RegisterAsync(string Name, string email, string password, string confirmPassword)
        {
            //IF NOT DEBUG
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Name = Name,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client
                .PostAsync("http://192.168.1.103:45455/api/Account/Register", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode,errorMessage);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",email),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, "http://192.168.1.103:45455/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);


            var content = await response.Content.ReadAsStringAsync(); //jwt

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessToken = jwtDynamic.Value<string>("access_token");

            Debug.WriteLine(content);

            return accessToken;
        }

        public async Task<(bool, string)> sendEmailVerificationAsync(string email , string OTPCode)
        {
            var client = new HttpClient();

            var model = new EmailVerificationBindingModel
            {
                TargetEmail = email,
                OTPCode = OTPCode
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client
                .PostAsync("http://192.168.1.103:45455/api/Account/sendEmailVerification", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }

        public async Task<(bool, string)> OTPVerification(string targetEmail)
        {
            var client = new HttpClient();

            var model = new EmailVerificationBindingModel
            {
                TargetEmail = targetEmail
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client
                .PostAsync("http://192.168.1.103:45455/api/Account/ConfirmEmail", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }

        public async Task<(bool, string)> CheckVerification(string targetEmail)
        {
            var client = new HttpClient();

            var model = new EmailVerificationBindingModel
            {
                TargetEmail = targetEmail,
                OTPCode = "000000",
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client
                .PostAsync("http://192.168.1.103:45455/api/Account/CheckVerification", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }
    }
}
