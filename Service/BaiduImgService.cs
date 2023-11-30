using AllInAI.Sharp.API.Constant;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllInAI.Sharp.API.Res.ImgRes;
using static AllInAI.Sharp.API.Res.OpenAIImageRes;

namespace AllInAI.Sharp.API.Service {
    internal class BaiduImgService : IImageService {
        public async Task<ImgRes> Txt2Img(HttpClient _httpClient, Txt2ImgReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = $"{BaiduModels.SDXLApiUrl}?access_token={accesstoken}";
            BaiduImgRes completionRes = await _httpClient.PostAndReadAsAsync<BaiduImgRes>(url, req, cancellationToken);
            ImgRes res=new ImgRes();
            res.ErrorCode=completionRes.ErrorCode;
            res.ErrorMsg=completionRes.ErrorMsg;
            if (completionRes.Successful) {
                List<ImageDataRes> imageDatas = new List<ImageDataRes>();
                foreach (var item in completionRes.Data)
                {
                    ImageDataRes image=new ImageDataRes();
                    image.B64 = item.B64Image;
                    imageDatas.Add(image);
                }
                res.CreatedAt = completionRes.Created;
                res.Results = imageDatas;
            }
            return res;
        }
    }
}
