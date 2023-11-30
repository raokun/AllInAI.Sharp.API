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

namespace AllInAI.Sharp.API.Service {
    internal class OpenAIImgService : IImageService {
        public async Task<ImgRes> Txt2Img(HttpClient _httpClient, Txt2ImgReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/v1/images/generations";
            OpenAIImgReq openAIImgReq = new OpenAIImgReq();
            openAIImgReq.Prompt = req.Prompt;
            openAIImgReq.N=req.N;
            openAIImgReq.Size = req.Size;
            openAIImgReq.ResponseFormat=req.ResponseFormat;
            ImgRes completionRes = await _httpClient.PostAndReadAsAsync<ImgRes>(url, openAIImgReq, cancellationToken);
            
            return completionRes;
        }
    }
}
