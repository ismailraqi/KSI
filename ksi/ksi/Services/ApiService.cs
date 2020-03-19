using ksi.Models;
using ksi.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ksi.Services
{
    class ApiService
    {
        private readonly string Uri = "http://192.168.1.104:45455";
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email=email,
                Password=password,
                ConfirmPassword=confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{Uri}/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<string>LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };
            var request = new HttpRequestMessage(HttpMethod.Post, $"{Uri}/Token");
            request.Content = new FormUrlEncodedContent(keyValues);
            var client = new HttpClient();
            var response=await client.SendAsync(request);
            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");
            Debug.WriteLine(jwt);
            return accessToken;
        }

        public async Task<List<AricleModel>> GetArticleAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                accessToken);
            var json = await client.GetStringAsync($"{Uri}/api/Articles");
            var articles = JsonConvert.DeserializeObject<List<AricleModel>>(json);
            return articles;
        }

        public async Task PostArticleAsync( AricleModel article, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                accessToken);
            var json = JsonConvert.SerializeObject(article);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{Uri}/api/Articles", content);

        }

        public async Task PostRepAsync(responses reponses)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
            //    accessToken);
            var json = JsonConvert.SerializeObject(reponses);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{Uri}/api/Quests", content);

        }
    }
}
