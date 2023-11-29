using AllInAI.Sharp.API.Constant;
using AllInAI.Sharp.API.Extensions;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Utils;
using System.Text.Json;
using System;

namespace AllInAI.Sharp.API.Service;

public class BaiduChatService: IChatService
{
    public async Task<CompletionRes> Completion(HttpClient _httpClient,CompletionReq req, string? accesstoken = null, CancellationToken cancellationToken = default)
    {
        string url =$"{BaiduModels.ApiUrl}{req.Model}?access_token={accesstoken}";
        BaiDuCompletionRes completionRes = await _httpClient.PostAndReadAsAsync<BaiDuCompletionRes>(url, req, cancellationToken);
        return completionRes;
    }

    public async IAsyncEnumerable<CompletionRes> CompletionStream(HttpClient _httpClient,CompletionReq req, string? accesstoken = null, CancellationToken cancellationToken = default)
    {
        string url = $"{BaiduModels.ApiUrl}{req.Model}?access_token={accesstoken}";
        req.Stream = true;
        using var response = _httpClient.PostAsStreamAsync(url, req, cancellationToken);
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);
        while (!reader.EndOfStream) {
            cancellationToken.ThrowIfCancellationRequested();

            var line = await reader.ReadLineAsync();
            // Skip empty lines
            if (string.IsNullOrEmpty(line)) {
                continue;
            }

            line = line.RemoveIfStartWith("data: ");
            BaiDuCompletionRes res;
            try {
                // When the response is good, each line is a serializable CompletionCreateRequest
                res = JsonSerializer.Deserialize<BaiDuCompletionRes>(line);
                // Exit the loop if the stream is done
                if (res.IsEnd = true) {
                    break;
                }
            }
            catch (Exception) {
                // When the API returns an error, it does not come back as a block, it returns a single character of text ("{").
                // In this instance, read through the rest of the response, which should be a complete object to parse.
                line += await reader.ReadToEndAsync();
                res = JsonSerializer.Deserialize<BaiDuCompletionRes>(line);
            }
            if (null != res) {
                yield return res;
            }
        }
    }
}