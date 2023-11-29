using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace AllInAI.Sharp.API.Service {
    public class AuthService {
        private readonly HttpClient _httpClient;
        public AuthService(String BaseUrl, HttpClient? httpClient = null) {
            if (httpClient == null) {
                _httpClient = new HttpClient();
            }
            else {
                _httpClient = httpClient;
            }
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="client_id">应用的API Key，在智能云千帆控制台-应用列表查看</param>
        /// <param name="client_secret">应用的Secret Key，在智能云千帆控制台-应用列表查看</param>
        /// https://console.bce.baidu.com/qianfan/ais/console/applicationConsole/application
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<BaiduTokenRes> GetTokenAsyncForBaidu(string client_id, string client_secret) {
            if (string.IsNullOrEmpty(client_id) || string.IsNullOrEmpty(client_secret)) {
                throw new FormatException("client_id and client_secret mast not be null");
            }
            string url = $"/oauth/2.0/token?grant_type=client_credentials&client_id={client_id}&client_secret={client_secret}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadFromJsonAsync<BaiduTokenRes>();

            }
            else {
                throw new HttpRequestException($"Error：{response.StatusCode},{response.Content}");
            }
        }
    }
}
