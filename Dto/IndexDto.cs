using AllInAI.Sharp.API.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Dto {

    public record IndexDto {
        public  string Name { get; init; }
        public  uint Dimension { get; init; }
        public  Metric Metric { get; init; }
        public long? Pods { get; init; }
        [JsonPropertyName("pod_type")]
        public string? PodType { get; init; }
        public long? Replicas { get; init; }
        [JsonPropertyName("metadata_config")]
        public Dictionary<string, object> MetadataConfig { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Metric {
        [JsonPropertyName("cosine")] Cosine = 0,
        [JsonPropertyName("dotproduct")] DotProduct = 1,
        [JsonPropertyName("euclidean")] Euclidean = 2
    }

    public record IndexStatus {
        [JsonPropertyName("ready")]
        public required bool IsReady { get; init; }
        public required IndexState State { get; init; }
        public required string Host { get; init; }
        public required int Port { get; init; }
        public string?[]? Waiting { get; init; }
        public string?[]? Crashed { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IndexState {
        Initializing = 0,
        ScalingUp = 1,
        ScalingDown = 2,
        Terminating = 3,
        Ready = 4,
        ScalingUpPodSize = 5,
        ScalingDownPodSize = 6,
        InitializationFailed = 7
    }

    public record IndexStats {
        [JsonConverter(typeof(IndexNamespaceArrayConverter))]
        public required IndexNamespace[] Namespaces { get; init; }
        public required uint Dimension { get; init; }
        public required float IndexFullness { get; init; }
        public required uint TotalVectorCount { get; init; }
    }

    public readonly record struct IndexNamespace {
        public required string Name { get; init; }
        public required uint VectorCount { get; init; }
    }
}
