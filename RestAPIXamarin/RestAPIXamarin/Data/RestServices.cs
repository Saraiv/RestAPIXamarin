using Newtonsoft.Json;
using RestAPIXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIXamarin.Data
{
    public class RestServices{
        HttpClient client;
        string grant_type = "password";

        public RestServices(){
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(User user){
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.username));
            postData.Add(new KeyValuePair<string, string>("password", user.password));
            var content = new FormUrlEncodedContent(postData);
            var webUrl = "www.test.com";
            var response = await PostResponseLogin<Token>(Constants.loginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expireDate = dt.AddSeconds(response.expireIn);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string webUrl, FormUrlEncodedContent content) where T : class{
            var response = await client.PostAsync(webUrl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var reponseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return reponseObject;
        }

        public async Task<T> PostResponse<T>(string webUrl, string jsonString) where T : class{
            var token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
            try{
                var result = await client.PostAsync(webUrl, new StringContent(jsonString, Encoding.UTF8, ContentType));
                if(result.StatusCode == System.Net.HttpStatusCode.OK){
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try{
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    } catch { return null; }
                }
            } catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(string webUrl) where T : class{
            var token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
            try
            {
                var response = await client.GetAsync(webUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }
    }
}
