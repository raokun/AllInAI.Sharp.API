using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record EmbeddingRes: BaseRes {
        [JsonPropertyName("model")] public string Model { get; set; }

        [JsonPropertyName("data")] public List<EmbeddingData> Data { get; set; }

        [JsonPropertyName("usage")] public UsageRes Usage { get; set; }
    }

    public record EmbeddingData {
        [JsonPropertyName("index")] public int? Index { get; set; }

        [JsonPropertyName("embedding")] public float[] Embedding { get; set; }
    }
}
