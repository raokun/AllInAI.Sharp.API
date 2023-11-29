using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    /// <summary>
    /// 聊天提问模型
    /// </summary>
    public record CompletionRes : BaseRes {
        [JsonPropertyName("object")] public string? ObjectTypeName { get; set; }
        [JsonPropertyName("model")] public string? Model { get; set; }

        [JsonPropertyName("choices")] public List<ChatChoiceRes>? Choices { get; set; }

        [JsonPropertyName("result")] public string? Result { get; set; }
        [JsonPropertyName("usage")] public UsageRes? Usage { get; set; }

        [JsonPropertyName("created")] public int? CreatedAt { get; set; }

        [JsonPropertyName("id")] public string? Id { get; set; }
    }
}
