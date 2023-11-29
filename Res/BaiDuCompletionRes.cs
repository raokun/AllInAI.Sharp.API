using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Res {
    internal record BaiDuCompletionRes:CompletionRes {
        /// <summary>
        /// 表示当前子句的序号。只有在流式接口模式下会返回该字段
        /// </summary>
        [JsonPropertyName("sentence_id")] public int? SentenceId { get; set; }
        /// <summary>
        /// 表示当前子句是否是最后一句。只有在流式接口模式下会返回该字段
        /// </summary>
        [JsonPropertyName("is_end")] public bool IsEnd { get; set; }
        /// <summary>
        /// 当前生成的结果是否被截断
        /// </summary>
        [JsonPropertyName("is_truncated")] public bool IsTruncated { get; set; }

        [JsonPropertyName("need_clear_history")] public bool NeedClearHistory { get; set; }

        [JsonPropertyName("error_code")] public int? ErrorCode { get; set; }

        [JsonPropertyName("error_msg")] public string? ErrorMsg { get; set; }
    }
}
