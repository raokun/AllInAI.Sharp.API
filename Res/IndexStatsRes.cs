using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {

    public class IndexStatsRes {
        public Namespaces namespaces { get; set; }
        public int dimension { get; set; }
        public float index_fullness { get; set; }
    }

    public class Namespaces {
        public Child _ { get; set; }
        public ExampleNamespace2 examplenamespace2 { get; set; }
    }

    public class Child {
        public int vectorCount { get; set; }
    }

    public class ExampleNamespace2 {
        public int vectorCount { get; set; }
    }

}
