using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.IService {
    /// <summary>
    /// 聊天模型接口
    /// </summary>
    public interface IChatService {
        /// <summary>
        /// 聊天接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        CompletionRes Completion(CompletionReq req);

        /// <summary>
        /// 聊天接口（流式传输）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        IAsyncEnumerable<CompletionRes> CompletionStream(CompletionReq req);
    }
}
