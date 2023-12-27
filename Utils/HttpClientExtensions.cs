using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Res.Vector;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AllInAI.Sharp.API.Utils;

public static class HttpClientExtensions {
    public static async Task<TResponse> PostAndReadAsAsync<TResponse>(this HttpClient client, string uri, object? requestModel, CancellationToken cancellationToken = default) {
        try {
            var response = requestModel == null ? await client.PostAsync(uri, null) : await client.PostAsJsonAsync(uri, requestModel, new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // 设置属性命名策略为小写开头驼峰命名
            }, cancellationToken);
            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
            }
            else {
                throw new HttpRequestException($"Error：{(int)response.StatusCode},{await response.Content.ReadAsStringAsync()}");
            }
        }catch (Exception ex) {
            var error=ex.Message;
            throw ex;
        }
    }

    public static async Task<string> PostAndReadAsStringAsync(this HttpClient client, string uri, object? requestModel, CancellationToken cancellationToken = default) {
        var response = await client.PostAsJsonAsync(uri, requestModel, new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // 设置属性命名策略为小写开头驼峰命名
        }, cancellationToken);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
        }
        else {
            throw new HttpRequestException($"Error：{(int)response.StatusCode},{await response.Content.ReadAsStringAsync()}");
        }
        
    }

    public static async Task<TResponse> PostAndReadAsDataAsync<TResponse, TData>(this HttpClient client, string uri, object? requestModel, CancellationToken cancellationToken = default) where TResponse : DataBaseRes<TData>, new() {
        var response = await client.PostAsJsonAsync(uri, requestModel, new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        }, cancellationToken);

        if (!response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
        }

        TData data;
        if (typeof(TData) == typeof(byte[])) {
            data = (TData)(object)await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
        else if (typeof(TData) == typeof(Stream)) {
            data = (TData)(object)await response.Content.ReadAsStreamAsync(cancellationToken);
        }
        else if (typeof(TData) == typeof(string)) {
            data = (TData)(object)await response.Content.ReadAsStringAsync(cancellationToken);
        }
        else {
            throw new NotSupportedException("Unsupported type for TData");
        }

        return new TResponse { Data = data };
    }


    public static HttpResponseMessage PostAsStreamAsync(this HttpClient client, string uri, object requestModel, CancellationToken cancellationToken = default) {
        var settings = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        var content = JsonContent.Create(requestModel, null, settings);

        using var request = CreatePostEventStreamRequest(uri, content);

#if NET6_0_OR_GREATER
        try {
            return client.Send(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        }
        catch (PlatformNotSupportedException) {
            using var newRequest = CreatePostEventStreamRequest(uri, content);

            return SendRequestPreNet6(client, newRequest, cancellationToken);
        }
#else
        return SendRequestPreNet6(client, request, cancellationToken);
#endif
    }

    private static HttpResponseMessage SendRequestPreNet6(HttpClient client, HttpRequestMessage request, CancellationToken cancellationToken) {
        var responseTask = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var response = responseTask.GetAwaiter().GetResult();
        return response;
    }

    private static HttpRequestMessage CreatePostEventStreamRequest(string uri, HttpContent content) {
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        request.Content = content;

        return request;
    }

    public static async Task<TResponse> PostFileAndReadAsAsync<TResponse>(this HttpClient client, string uri, HttpContent content, CancellationToken cancellationToken = default) {
        var response = await client.PostAsync(uri, content, cancellationToken);
        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
    }

    public static async Task<string> PostFileAndReadAsStringAsync(this HttpClient client, string uri, HttpContent content, CancellationToken cancellationToken = default) {
        var response = await client.PostAsync(uri, content, cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken) ?? throw new InvalidOperationException();
    }

    public static async Task<TResponse> DeleteAndReadAsAsync<TResponse>(this HttpClient client, string uri, CancellationToken cancellationToken = default) {
        var response = await client.DeleteAsync(uri, cancellationToken);
        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
    }
    public static async Task<string> DeleteAndReadAsStringAsync(this HttpClient client, string uri, CancellationToken cancellationToken = default) {
        var response = await client.DeleteAsync(uri, cancellationToken);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken) ?? throw new InvalidOperationException();
        }
        else {
            throw new HttpRequestException($"Error：{(int)response.StatusCode},{await response.Content.ReadAsStringAsync()}");
        }
    }

    public static async Task<string> PatchAndReadAsStringAsync(this HttpClient client, string uri, HttpContent content) {
        var request = new HttpRequestMessage(HttpMethod.Patch, uri);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        request.Content= content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadAsStringAsync();

        }
        else {
            throw new HttpRequestException($"Error：{(int)response.StatusCode},{await response.Content.ReadAsStringAsync()}");
        }
        
    }
   

    public static async Task<T> GetAsync<T>(this HttpClient client, string uri) {
        HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<T>();

        }
        else {
            throw new HttpRequestException($"Error：{response.StatusCode},{response.Content}");
        }
    }
    public static async Task<List<T>> GetAsyncAsList<T>(this HttpClient client, string uri) {
        HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode) {
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(body);

        }
        else {
            throw new HttpRequestException($"Error：{response.StatusCode},{response.Content}");
        }
    }

#if NETSTANDARD2_0
    public static async Task<string> ReadAsStringAsync(this HttpContent content, CancellationToken cancellationToken)
    {
        var stream = await content.ReadAsStreamAsync().WithCancellation(cancellationToken);
        using var sr = new StreamReader(stream);
        return await sr.ReadToEndAsync().WithCancellation(cancellationToken);
    }

    public static async Task<AsyncDisposableStream> ReadAsStreamAsync(this HttpContent content, CancellationToken cancellationToken)
    {
        var stream = await content.ReadAsStreamAsync().WithCancellation(cancellationToken);
        return new AsyncDisposableStream(stream);
    }

    public static async Task<byte[]> ReadAsByteArrayAsync(this HttpContent content, CancellationToken cancellationToken)
    {
        return await content.ReadAsByteArrayAsync().WithCancellation(cancellationToken);
    }

    public static async Task<Stream> GetStreamAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken)
    {
        var response = await client.GetAsync(requestUri, cancellationToken);
        return await response.Content.ReadAsStreamAsync(cancellationToken);
    }

    public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>();
        using (cancellationToken.Register(s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs))
        {
            if (task != await Task.WhenAny(task, tcs.Task))
            {
                throw new OperationCanceledException(cancellationToken);
            }
        }

        return await task;
    }
#endif
}