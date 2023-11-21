using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req
{
    /// <summary>
    /// 百度文心千帆
    /// </summary>
    public class BaiduAuthReq
    {
        /// <summary>
        /// client_id
        /// </summary>
        public string client_id {  get; set; }
        /// <summary>
        /// client_secret
        /// </summary>
        public string client_secret { get; set;}
    }
}
