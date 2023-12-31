﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Dto {
    public record AliParameter {
        /// <summary>
        /// "text"表示旧版本的text
        /// "message"表示兼容openai的message
        /// </summary>
        [JsonPropertyName("result_format")]
        public string? ResultFormat { get; set; } = "message";
        /// <summary>
        /// 生成时，随机数的种子，用于控制模型生成的随机性。如果使用相同的种子，每次运行生成的结果都将相同；当需要复现模型的生成结果时，可以使用相同的种子。seed参数支持无符号64位整数类型。默认值 1234
        /// </summary>
        [JsonPropertyName("seed")]
        public int? Seed { get; set; }
        /// <summary>
        /// 生成时，核采样方法的概率阈值。例如，取值为0.8时，仅保留累计概率之和大于等于0.8的概率分布中的token，作为随机采样的候选集。取值范围为（0,1.0)，取值越大，生成的随机性越高；取值越低，生成的随机性越低。默认值为0.8。注意，取值不要大于等于1
        /// </summary>
        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }
        /// <summary>
        /// 生成时，采样候选集的大小。例如，取值为50时，仅将单次生成中得分最高的50个token组成随机采样的候选集。取值越大，生成的随机性越高；取值越小，生成的确定性越高。注意：如果top_k参数为空或者top_k的值大于100，表示不启用top_k策略，此时仅有top_p策略生效，默认是空。
        /// </summary>
        [JsonPropertyName("top_k")]
        public double? topK { get; set; }

        /// <summary>
        /// 用于限制模型生成token的数量，max_tokens设置的是生成上限，并不表示一定会生成这么多的token数量。最大值和默认值均为1500
        /// </summary>
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }
        /// <summary>
        /// 用于控制模型生成时的重复度。提高repetition_penalty时可以降低模型生成的重复度。1.0表示不做惩罚。默认为1.1。
        /// </summary>
        [JsonPropertyName("repetition_penalty")]
        public double? RepetitionPenalty { get; set; }
        /// <summary>
        /// 用于控制随机性和多样性的程度。具体来说，temperature值控制了生成文本时对每个候选词的概率分布进行平滑的程度。较高的temperature值会降低概率分布的峰值，使得更多的低概率词被选择，生成结果更加多样化；而较低的temperature值则会增强概率分布的峰值，使得高概率词更容易被选择，生成结果更加确定。
        /// 取值范围： (0, 2),系统默认值1.0
        /// </summary>
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }
        /// <summary>
        /// 生成时，是否参考搜索的结果。注意：打开搜索并不意味着一定会使用搜索结果；如果打开搜索，模型会将搜索结果作为prompt，进而“自行判断”是否生成结合搜索结果的文本，默认为false
        /// </summary>
        [JsonPropertyName("enable_search")]
        public bool? EnableSearch { get; set; }
        /// <summary>
        /// 用于控制生成时遇到某些内容则停止。如果指定了字符串或者token_ids，模型将要生成指定字符串或者token_ids时会停止生成，生成结果不包含指定的内容。例如指定stop为"你好"，表示将要生成"你好"时停止；指定stop为[37763, 367]，表示将要生成"Observation"时停止。同时，stop参数支持以list方式传入字符串数组或者token_ids数组，以期支持使用多个stop的场景。注意，list模式下不支持字符串和token_ids混用，list模式下每个元素类型要相同。
        /// </summary>
        [JsonPropertyName("stop")]
        public IList<string> StopSequences { get; set; } = Array.Empty<string>();
        /// <summary>
        /// 用于控制流式输出模式，默认False，即后面内容会包含已经输出的内容；设置为True，将开启增量输出模式，后面输出不会包含已经输出的内容，您需要自行拼接整体输出，参考流式输出示例代码。
        /// 默认False
        /// </summary>
        [JsonPropertyName("incremental_output")]
        public bool? IncrementalOutput { get; set; }
    }
}
