using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;

namespace AllInAI.Sharp.API.Service;

public class ChatService
{
    private readonly HttpClient _httpClient;
    private readonly IChatService _chatService;
    public ChatService(AuthOption option,HttpClient? httpClient = null) {

        if (httpClient == null) {
            _httpClient = new HttpClient();
        }
        else {
            _httpClient = httpClient;
        }

        _httpClient.BaseAddress =new Uri(option.BaseUrl);
        switch (option.AIType)
        {
            case AITypeEnum.Baidu:
                accessToken = option.Key;
                _chatService = new BaiduChatService();
                break;
            case AITypeEnum.Ali:
                _chatService = new AliChatService();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {option.Key}");
                break;
            case AITypeEnum.OpenAi:
            default:
                _chatService = new OpenAIService();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {option.Key}");
                break;
        }
        
    }

    private string? accessToken;
    
    public async Task<CompletionRes> Completion(CompletionReq req)
    {
        return await _chatService.Completion(_httpClient, req);
    }

    public IAsyncEnumerable<CompletionRes> CompletionStream(CompletionReq req) {
        return _chatService.CompletionStream(_httpClient, req);
    }
}