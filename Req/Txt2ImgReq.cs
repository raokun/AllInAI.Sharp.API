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
        /// <summary>
        /// only dall-e-2 or dall-e-3 Defaults to dall-e-2
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }
        /// <summary>
        /// The quality of the image that will be generated. hd creates images with finer details and greater consistency across the image. This param is only supported for dall-e-3.
        /// </summary>
        [JsonPropertyName("quality")]
        public string? Quality { get; set; }
        /// <summary>
        /// The style of the generated images. Must be one of vivid or natural. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for dall-e-3.
        /// </summary>
        [JsonPropertyName("style")]
        public string? Style { get; set; }
    }
}
