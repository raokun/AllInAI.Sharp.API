using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record OpenAIImageRes:BaseRes {
        [JsonPropertyName("data")] public List<ImageDataRes> Results { get; set; }

        [JsonPropertyName("created")] public int? CreatedAt { get; set; }

        public record ImageDataRes {
            [JsonPropertyName("url")] public string? Url { get; set; }
            [JsonPropertyName("b64_json")] public string? B64 { get; set; }
        }
    }
}
