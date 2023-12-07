using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Service {
    /// <summary>
    /// 语音服务
    /// </summary>
    public class AudioService {
        private readonly HttpClient _httpClient;
        private readonly IAudioService _audioService;
        public AudioService(AuthOption option, HttpClient? httpClient = null) {

            if (httpClient == null) {
                _httpClient = new HttpClient();
            }
            else {
                _httpClient = httpClient;
            }

            _httpClient.BaseAddress = new Uri(option.BaseUrl);
            switch (option.AIType) {
                case AITypeEnum.OpenAi:
                default:
                    _audioService = new OpenAIAudioService();
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {option.Key}");
                    break;
            }

        }

        private string? accessToken;

         public async Task<AudioSpeechRes<T>> Speech<T>(AudioSpeechReq req) {
            return await _audioService.Speech<T>(_httpClient, req, accessToken);
        }

        public async Task<AudioTranscriptionRes> Transcriptions( AudioCreateTranscriptionReq req) {
            return await _audioService.Transcriptions(_httpClient, req, accessToken);
        }
    }
}
