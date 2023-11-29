using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record BaiduTokenRes {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
        public string refresh_token { get; set; }
        public string session_key { get; set; }
        public string scope { get; set; }
        public string session_secret { get; set; }
    }
}
