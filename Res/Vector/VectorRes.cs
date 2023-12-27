using AllInAI.Sharp.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res.Vector {
    public record VectorQueryRes {
        public  ScoredVector[] Matches { get; init; }
        public  string Namespace { get; init; }
    }
    public record VectorUpsertRes {
        public  uint UpsertedCount { get; init; }
    }

}
