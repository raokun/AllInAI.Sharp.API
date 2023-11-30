using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    public class Txt2ImgReq: BaiduImgReq {
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.(used in openai)
        /// </summary>
        [JsonPropertyName("response_format")]
        public string? ResponseFormat { get; set; }
    }
}
