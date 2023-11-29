using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    internal class BaiduCompletionReq:CompletionReq {
        [JsonPropertyName("system")]
        public string? System { get; set; }
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }
    }
}
