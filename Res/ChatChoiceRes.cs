using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    internal class ChatChoiceRes {
        [JsonPropertyName("message")] public MessageDto Message { get; set; }

        [JsonPropertyName("index")] public int? Index { get; set; }

        [JsonPropertyName("finish_reason")] public string FinishReason { get; set; }
    }
}
