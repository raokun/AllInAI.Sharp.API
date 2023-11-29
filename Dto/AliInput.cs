using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Dto {
    public record AliInput {
        [JsonPropertyName("messages")]
        public IList<MessageDto> Messages { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
    }
}
