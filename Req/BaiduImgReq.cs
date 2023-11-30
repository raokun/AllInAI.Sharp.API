using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    public class BaiduImgReq {
        /// <summary>
        /// 提示词，即用户希望图片包含的元素。长度限制为1024字符，建议中文或者英文单词总数量不超过150个
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        /// <summary>
        /// 生成图片数量
        /// 默认值为1
        /// 取值范围为1-4
        /// 单次生成的图片较多及请求较频繁可能导致请求超时
        /// </summary>
        [JsonPropertyName("n")]
        public int? N { get; set; }
        /// <summary>
        /// 生成图片长宽，默认值 1024x1024
        ///取值范围如下： ["768x768", "768x1024", "1024x768", "576x1024", "1024x576", "1024x1024"]
        /// </summary>
        [JsonPropertyName("size")]
        public string? Size { get; set; }
        /// <summary>
        /// 反向提示词，即用户希望图片不包含的元素。长度限制为1024字符，建议中文或者英文单词总数量不超过150个
        /// </summary>
        [JsonPropertyName("negative_prompt")]
        public string? NegativePrompt { get; set; }
        /// <summary>
        /// 迭代轮次,默认值为20
        /// 取值范围为10-50
        /// </summary>
        [JsonPropertyName("steps")]
        public int? Steps { get; set; }
        /// <summary>
        /// 采样方式，默认值：Euler a
        /// </summary>
        [JsonPropertyName("sampler_index")]
        public string? SamplerIndex { get; set; }
        /// <summary>
        /// 表示最终用户的唯一标识符，可以监视和检测滥用行为，防止接口恶意调用
        /// </summary>
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }
    }
}
