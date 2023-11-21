using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;

namespace AllInAI.Sharp.API.Service;

public class AliChatService: IChatService
{
    public async Task<CompletionRes> Completion(HttpClient _httpClient,CompletionReq req, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<CompletionRes> CompletionStream(HttpClient _httpClient,CompletionReq req, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}