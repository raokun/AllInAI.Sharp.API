using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record AliCompletionRes : BaseRes {
        [JsonPropertyName("request_id")] public string RequestId { get; set; }

        [JsonPropertyName("output")] public AliOutput Output { get; set; }

        [JsonPropertyName("usage")] public AliUsage Usage { get; set; }
    }
    public record AliOutput {
        [JsonPropertyName("text")] public string Text { get; set; }
        [JsonPropertyName("finish_reason")] public string FinishReason { get; set; }

        [JsonPropertyName("choices")] public List<ChatChoiceRes>? Choices { get; set; }
    }
    public record AliUsage {
        [JsonPropertyName("output_tokens")]
        public int OutputTokens { get; set; }

        [JsonPropertyName("input_tokens")]
        public int InputTokens { get; set; }
    }
}
