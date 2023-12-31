﻿using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    public record VectorQueryReq {
        public string? Id { get; set; }
        public float[]? Vector { get; set; }
        public SparseVector? SparseVector { get; set; }
        public  uint TopK { get; init; }
        public MetadataMap? Filter { get; init; }
        public  string Namespace { get; init; }
        public  bool IncludeValues { get; init; }
        public  bool IncludeMetadata { get; init; }
    }
    public record VectorUpsertReq {
        public  IEnumerable<VectorDto> Vectors { get; init; }
        public  string Namespace { get; init; }
    }
    public record VectorUpdateReq {
        public required string Id { get; init; }
        public required float[] Values { get; init; }
        public SparseVector? SparseValues { get; init; }
        public MetadataMap? SetMetadata { get; init; }
        public string Namespace { get; init; }
    }
}
