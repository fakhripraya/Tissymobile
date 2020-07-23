using EsrivaMobile.Helpers;
using EsrivaMobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
                .PostAsync($"http://{Settings.APILink}/api/Account/Register", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode,errorMessage);
        }

        public async Task<(string,string,string)> LoginAsync(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",email),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, $"http://{Settings.APILink}/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);


            var content = await response.Content.ReadAsStringAsync(); //jwt

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessToken = jwtDynamic.Value<string>("access_token");
            var tokenIssued = jwtDynamic.Value<string>(".issued"); 
            var dotExpires = jwtDynamic.Value<string>(".expires"); 

            Debug.WriteLine(content);

            return (accessToken, dotExpires, tokenIssued);
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
                .PostAsync($"http://{Settings.APILink}/api/Account/sendEmailVerification", content);

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
                .PostAsync($"http://{Settings.APILink}/api/Account/ConfirmEmail", content);

            var errorMessage = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, errorMessage);
        }

        public async Task<(bool, string, string)> CheckVerification(string targetEmail)
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
                .PostAsync($"http://{Settings.APILink}/api/Account/CheckVerification", content);

            var responseMessage = await response.Content.ReadAsStringAsync();
            if (responseMessage != "\"true\"" && responseMessage != "\"false\"")
            { 
                var userModel = JsonConvert.DeserializeObject<ExceptionResponse>(responseMessage);
                return (response.IsSuccessStatusCode, responseMessage, userModel.ExceptionMessage);
            }

            return (response.IsSuccessStatusCode, responseMessage, "OK");
        }

        public async Task<LoggedUserInfoModel> getUserInfoAsync()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            var response = await client.GetAsync($"http://{Settings.APILink}/api/Account/UserInfo");

            if (response.ReasonPhrase == "Unauthorized")
            {
                return new LoggedUserInfoModel
                {
                    UserId = "Unauthorized"
                };
            }

            var userInfo = await response.Content.ReadAsStringAsync();

            var userModel = JsonConvert.DeserializeObject<LoggedUserInfoModel>(userInfo);

            return userModel;
        }
    }
}
