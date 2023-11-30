using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    public record BaiduImgRes:BaseRes {
        /// <summary>
        /// 请求的id
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonPropertyName("created")]
        public int? Created { get; set; }
        /// <summary>
        /// 生成图片结果
        /// </summary>
        [JsonPropertyName("data")]
        public List<ImageData>? Data { get; set; }
        /// <summary>
        /// token统计信息
        /// </summary>
        [JsonPropertyName("usage")]
        public BaiduUsageRes? Usage { get; set; }

    }
    public record BaiduUsageRes {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
    public class ImageData {
        /// <summary>
        /// 固定值"image"
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }
        /// <summary>
        /// 图片base64编码内容
        /// </summary>
        [JsonPropertyName("b64_image")]
        public string? B64Image { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [JsonPropertyName("index")]
        public int? Index{ get; set; }
    }
}
