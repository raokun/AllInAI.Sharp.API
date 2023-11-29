using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    /// <summary>
    /// 通义千问
    /// </summary>
    public record AliCompletionReq {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("input")]
        public AliInput Input { get; set; }=new AliInput();
        [JsonPropertyName("parameters")]
        public AliParameter Parameters { get; set; }=new AliParameter();
    }
}
