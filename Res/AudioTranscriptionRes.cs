using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record AudioTranscriptionRes:BaseRes {
        [JsonPropertyName("text")] public string Text { get; set; }
    }
}
