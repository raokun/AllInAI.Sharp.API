using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Service {
    public class OpenAIAudioService : IAudioService {

        public async Task<AudioSpeechRes<T>> Speech<T>(HttpClient _httpClient, AudioSpeechReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/audio/speech";
            return await _httpClient.PostAndReadAsDataAsync<AudioSpeechRes<T>, T>(url, req, cancellationToken);
        }

        public async Task<AudioTranscriptionRes> Transcriptions(HttpClient _httpClient, AudioCreateTranscriptionReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/audio/transcriptions";
            if (req is { File: not null, FileStream: not null }) {
                throw new ArgumentException("Either File or FileStream must be set, but not both.");
            }
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(req.Model), "model");
            if (req.File != null) {
                content.Add(new ByteArrayContent(req.File), "file", req.FileName);
            }
            else if(req.FileStream != null) {
                content.Add(new StreamContent(req.FileStream), "file", req.FileName);
            }
            if(req.Prompt != null) {
                content.Add(new StringContent(req.Prompt), "prompt");
            }
            if (req.Language != null) {
                content.Add(new StringContent(req.Language), "prompt");
            }
            if (req.ResponseFormat != null) {
                content.Add(new StringContent(req.ResponseFormat), "response_format");
            }
            if (req.Temperature != null) {
                content.Add(new StringContent(req.Temperature.ToString()!), "temperature");
            }
            return await _httpClient.PostFileAndReadAsAsync<AudioTranscriptionRes>(url, content, cancellationToken);
        }
    }
}
