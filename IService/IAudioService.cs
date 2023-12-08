using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.IService {
    public interface IAudioService {
        Task<AudioSpeechRes<T>> Speech<T>( HttpClient _httpClient, AudioSpeechReq req, string? accesstoken = null, CancellationToken cancellationToken = default);

        Task<AudioTranscriptionRes> Transcriptions(HttpClient _httpClient, AudioCreateTranscriptionReq req, string? accesstoken = null, CancellationToken cancellationToken = default);

        Task<AudioTranscriptionRes> Translations(HttpClient _httpClient, AudioCreateTranscriptionReq req, string? accesstoken = null, CancellationToken cancellationToken = default);
    }
}
