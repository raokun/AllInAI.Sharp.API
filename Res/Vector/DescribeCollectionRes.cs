using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res.Vector {
    public record DescribeCollectionRes {
        public required string Name { get; init; }
        public required long Size { get; init; }
        public required string Status { get; init; }
        public required long Dimension { get; init; }
        [JsonPropertyName("vector_count")]
        public required long VectorCount { get; init; }
    }
}
