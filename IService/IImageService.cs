using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.IService {
    /// <summary>
    /// 图片模型接口
    /// </summary>
    internal interface IImageService {
        /// <summary>
        /// 文生图
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        ImgRes Txt2Img(Txt2ImgReq req);
    }
}
