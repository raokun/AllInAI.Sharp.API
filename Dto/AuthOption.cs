using AllInAI.Sharp.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Dto {
    public class AuthOption {
        /// <summary>
        /// 代理地址
        /// </summary>
        public string BaseUrl { get; set; }

        public string Key { get; set; }

        public AITypeEnum AIType { get; set; }

    }
}
