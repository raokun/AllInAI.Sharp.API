using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record BaseRes {
        [JsonPropertyName("object")] public string? ObjectTypeName { get; set; }
        public bool Successful => (Error == null && ErrorCode == null);
        [JsonPropertyName("error")] public Error? Error { get; set; }

        [JsonPropertyName("error_code")] public int? ErrorCode { get; set; }

        [JsonPropertyName("error_msg")] public string? ErrorMsg { get; set; }
    }

    public record Error {
        [JsonPropertyName("code")] public string? Code { get; set; }

        [JsonPropertyName("message")] public string? Message { get; set; }

        [JsonPropertyName("param")] public string? Param { get; set; }

        [JsonPropertyName("type")] public string? Type { get; set; }
    }

    public record DataBaseRes<T> : BaseRes {
        [JsonPropertyName("data")] public T? Data { get; set; }
    }
}
