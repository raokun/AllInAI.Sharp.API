using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    internal class OpenAICompletionReq {
        [JsonPropertyName("messages")]
        public IList<MessageDto> Messages { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0;

        [JsonPropertyName("top_p")]
        public double TopP { get; set; } = 0;

        [JsonPropertyName("n")]
        public int? N { get; set; }

        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }

        [JsonPropertyName("stop")]
        public IList<string> StopSequences { get; set; } = Array.Empty<string>();

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        [JsonPropertyName("presence_penalty")]
        public double PresencePenalty { get; set; } = 0;

        [JsonPropertyName("frequency_penalty")]
        public double FrequencyPenalty { get; set; } = 0;

        [JsonPropertyName("logit_bias")]
        public IDictionary<int, int> TokenSelectionBiases { get; set; } = new Dictionary<int, int>();
    }
}
