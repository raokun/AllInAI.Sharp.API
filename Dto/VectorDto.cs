﻿using AllInAI.Sharp.API.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Dto {

    public record VectorDto {
        public required string Id { get; set; }
        public required float[]? Values { get; set; }
        public SparseVector? SparseValues { get; set; }
        public MetadataMap? Metadata { get; set; }
    }

    public readonly record struct SparseVector {
        public required uint[] Indices { get; init; }
        public required float[] Values { get; init; }
    }

    public record ScoredVector {
        public required string Id { get; set; }
        public required double Score { get; set; }
        public float[]? Values { get; set; }
        public SparseVector? SparseValues { get; set; }
        public MetadataMap? Metadata { get; set; }
    }

    public sealed class MetadataMap : Dictionary<string, MetadataValue> {
        public MetadataMap() : base() { }
        public MetadataMap(IEnumerable<KeyValuePair<string, MetadataValue>> collection) : base(collection) { }
    }

    [JsonConverter(typeof(MetadataValueConverter))]
    public readonly record struct MetadataValue {
        public object? Inner { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal MetadataValue(object? value) => Inner = value;

        // Main supported types
        public static implicit operator MetadataValue(bool value) => new(value);
        public static implicit operator MetadataValue(string? value) => new(value);
        public static implicit operator MetadataValue(int value) => new((double)value);
        public static implicit operator MetadataValue(long value) => new((double)value);
        public static implicit operator MetadataValue(float value) => new((double)value);
        public static implicit operator MetadataValue(double value) => new(value);
        public static implicit operator MetadataValue(decimal value) => new((double)value);
        public static implicit operator MetadataValue(MetadataMap? value) => new(value);
        public static implicit operator MetadataValue(MetadataValue[]? value) => new(value);
        public static implicit operator MetadataValue(List<MetadataValue>? value) => new(value);

        // Compatible conversions: arrays
        public static implicit operator MetadataValue(string[]? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(int[]? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(long[]? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(float[]? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(double[]? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(decimal[]? value) => new(value?.Select(v => (MetadataValue)v));

        // Compatible conversions: lists
        public static implicit operator MetadataValue(List<string>? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(List<int>? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(List<long>? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(List<float>? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(List<double>? value) => new(value?.Select(v => (MetadataValue)v));
        public static implicit operator MetadataValue(List<decimal>? value) => new(value?.Select(v => (MetadataValue)v));
    }
}
