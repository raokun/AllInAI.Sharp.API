using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    public class AudioSpeechReq {
        [JsonPropertyName("model")]
        public string? Model { get; set; }
        [JsonPropertyName("input")]
        public string? Input { get; set; }
        [JsonPropertyName("voice")]
        public string? Voice { get; set; }
    }
}
