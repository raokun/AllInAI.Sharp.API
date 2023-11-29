using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Constant {
    /// <summary>
    /// 文心千帆模型
    /// </summary>
    public static class BaiduModels {
        public static string ApiUrl = "/rpc/2.0/ai_custom/v1/wenxinworkshop/chat/";

        public static string ERNIE_Bot_4 = "completions_pro";
        public static string ERNIE_Bot_8K = "ernie_bot_8k";
        public static string ERNIE_Bot = "completions";
        public static string ERNIE_Bot_turbo = "eb-instant";
        public static string ERNIE_Bot_turbo_AI = "ai_apaas";
        public static string BLOOMZ_7B = "bloomz_7b1";
        public static string Qianfan_BLOOMZ_7B_compressed = "qianfan_bloomz_7b_compressed";
        public static string Llama_2_7b_chat = "llama_2_7b";
        public static string Llama_2_13b_chat = "llama_2_13b";
        public static string Llama_2_70b_chat = "llama_2_70b";
        public static string Qianfan_Chinese_Llama_2_7B = "qianfan_chinese_llama_2_7b";
        public static string Qianfan_Chinese_Llama_2_13B = "qianfan_chinese_llama_2_13b";
        public static string ChatGLM2_6B_32K = "chatglm2_6b_32k";
        public static string XuanYuan_70B_Chat_4bit = "xuanyuan_70b_chat";
        public static string AquilaChat_7B = "aquilachat_7b";
    }
}
