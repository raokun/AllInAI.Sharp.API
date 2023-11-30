using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    public class OpenAIImgReq {
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        [JsonPropertyName("n")]
        public int? N { get; set; }
        [JsonPropertyName("size")]
        public string? Size { get; set; }
        [JsonPropertyName("response_format")]
        public string? ResponseFormat { get; set; }
        [JsonPropertyName("user")]
        public string? User { get; set; }
    }
}
