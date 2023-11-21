using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System.Net.Http.Json;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.Utils;

namespace AllInAI.Sharp.API.Service
{
    public class OpenAIService : IChatService {
        

        public async Task<CompletionRes> Completion(HttpClient _httpClient,CompletionReq req, CancellationToken cancellationToken = default) {
            string url = "/v1/chat/completions";
            var res=await _httpClient.PostAsJsonAsync(url,req);
            return await _httpClient.PostAndReadAsAsync<CompletionRes>(url, req, cancellationToken);
        }

        public IAsyncEnumerable<CompletionRes> CompletionStream(HttpClient _httpClient,CompletionReq req, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        private async Task<OpenAICompletionRes> ChatCompletions(HttpClient _httpClient,OpenAICompletionReq req)
        {
            
            string url = "";
            var res=await _httpClient.PostAsJsonAsync(url,req);
            return new OpenAICompletionRes();
        }
    }
}