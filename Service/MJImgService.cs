using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Service {
    internal class MJImgService : IImageService {
        public Task<ImgRes> Txt2Img(HttpClient _httpClient, Txt2ImgReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }
    }
}
