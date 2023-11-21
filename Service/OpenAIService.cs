using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System.Net.Http.Json;

namespace AllInAI.Sharp.API.Service
{
    public class OpenAIService : IChatService {
        private readonly HttpClient _httpClient;

        public OpenAIService(HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public OpenAIService(AuthOption option,HttpClient? httpClient = null) {

            if (httpClient == null) {
                _httpClient = new HttpClient();
            }
            else {
                _httpClient = httpClient;
            }
        }

        public CompletionRes Completion(CompletionReq req) {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<CompletionRes> CompletionStream(CompletionReq req) {
            throw new NotImplementedException();
        }

        private async Task<OpenAICompletionRes> ChatCompletions(OpenAICompletionReq req) {
            _httpClient.PostAsJsonAsync();
            return new OpenAICompletionRes();
        }
    }
}