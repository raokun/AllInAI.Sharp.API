﻿using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Res;
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
        public  uint TopK { get; set; }
        public MetadataMap? Filter { get; set; }
        public  string Namespace { get; set; }
        public  bool IncludeValues { get; set; }
        public  bool IncludeMetadata { get; set; }
    }
    public record VectorUpsertReq {
        public  IEnumerable<VectorDto> Vectors { get; set; }
        public  string Namespace { get; set; }
    }
    public record VectorUpdateReq {
        public required string? Id { get; set; }
        public  float[]? Values { get; set; }
        public SparseVector? SparseValues { get; set; }
        public MetadataMap? SetMetadata { get; set; }
        public string? Namespace { get; set; }
    }
    public record VectorDeleteReq
    {
        public MetadataMap Filter { get; init; }

        public string? IndexNamespace { get; init; }
    }
}
