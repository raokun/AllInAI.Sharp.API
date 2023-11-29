using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AllInAI.Sharp.API.Dto;

namespace AllInAI.Sharp.API.Req {
    /// <summary>
    /// 聊天模型
    /// 
    /// </summary>
    public class CompletionReq {
        [JsonPropertyName("messages")]
        public IList<MessageDto> Messages { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }

        [JsonPropertyName("n")]
        public int? N { get; set; }

        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        [JsonPropertyName("stop")]
        public IList<string> StopSequences { get; set; } = Array.Empty<string>();

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        [JsonPropertyName("presence_penalty")]
        public double? PresencePenalty { get; set; }

        [JsonPropertyName("frequency_penalty")]
        public double? FrequencyPenalty { get; set; }

        [JsonPropertyName("logit_bias")]
        public IDictionary<int, int> TokenSelectionBiases { get; set; } = new Dictionary<int, int>();
    }
}
