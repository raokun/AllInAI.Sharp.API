﻿using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System.Net.Http.Json;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.Utils;
using AllInAI.Sharp.API.Extensions;
using System.Text.Json;
using AI.Dev.OpenAI.GPT;

namespace AllInAI.Sharp.API.Service
{
    public class OpenAIService : IChatService {


        public async Task<CompletionRes> Completion(HttpClient _httpClient, CompletionReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/chat/completions";
            CompletionRes completionRes = await _httpClient.PostAndReadAsAsync<CompletionRes>(url, req, cancellationToken);
            if (completionRes.Choices != null)
                completionRes.Result = completionRes.Choices[0].Message.Content;
            return completionRes;
        }

        public async IAsyncEnumerable<CompletionRes> CompletionStream(HttpClient _httpClient, CompletionReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/chat/completions";
            req.Stream = true;
            using var response = _httpClient.PostAsStreamAsync(url, req, cancellationToken);
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var reader = new StreamReader(stream);
            //计算token消耗
            var totalMsg = "";
            var promptTokens = 0;
            foreach (var item in req.Messages)
            {
                promptTokens+= GPT3Tokenizer.Encode(item.Content).Count();
            }
            var completionTokens = 0;
            while (!reader.EndOfStream) {
                cancellationToken.ThrowIfCancellationRequested();

                var line = await reader.ReadLineAsync();
                // Skip empty lines
                if (string.IsNullOrEmpty(line)) {
                    continue;
                }

                line = line.RemoveIfStartWith("data: ");

                // Exit the loop if the stream is done
                if (line.StartsWith("[DONE]")) {
                    break;
                }
                CompletionRes res;
                try {
                    // When the response is good, each line is a serializable CompletionCreateRequest
                    res = JsonSerializer.Deserialize<CompletionRes>(line);
                    res.Result = res.Choices[0].Delta.Content;
                    completionTokens+= GPT3Tokenizer.Encode(res.Choices[0].Delta.Content).Count();
                    if(res.Usage == null) {
                        res.Usage=new UsageRes() { CompletionTokens=completionTokens, PromptTokens =promptTokens,TotalTokens= promptTokens + completionTokens };
                    }
                }
                catch (Exception) {
                    // When the API returns an error, it does not come back as a block, it returns a single character of text ("{").
                    // In this instance, read through the rest of the response, which should be a complete object to parse.
                    line += await reader.ReadToEndAsync();
                    res = JsonSerializer.Deserialize<CompletionRes>(line);
                }
                if (null != res) {
                    yield return res;
                }
            }
        }

        public async Task<EmbeddingRes> Embedding(HttpClient _httpClient, EmbeddingReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/embeddings";
            EmbeddingRes res = await _httpClient.PostAndReadAsAsync<EmbeddingRes>(url, req, cancellationToken);
            return res;
        }

        private async Task<OpenAICompletionRes> ChatCompletions(HttpClient _httpClient,OpenAICompletionReq req)
        {
            
            string url = "";
            var res=await _httpClient.PostAsJsonAsync(url,req);
            return new OpenAICompletionRes();
        }
    }
}