using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllInAI.Sharp.API.Res.OpenAIImageRes;

namespace AllInAI.Sharp.API.Service {
    internal class SDImgService : IImageService {
        public async Task<ImgRes> Txt2Img(HttpClient _httpClient, Txt2ImgReq req, string? accesstoken = null, CancellationToken cancellationToken = default) {
            string url = "/sdapi/v1/txt2img";
            SDImgReq dto = new SDImgReq();
            dto.prompt = req.Prompt;
            dto.steps = req.Steps;
            dto.batch_size = req.N;
            dto.negative_prompt = req.NegativePrompt;

            SDImgRes completionRes = await _httpClient.PostAndReadAsAsync<SDImgRes>(url, dto, cancellationToken);
            ImgRes res = new ImgRes();
            if (completionRes.Successful) {
                List<ImageDataRes> imageDatas = new List<ImageDataRes>();
                foreach (var item in completionRes.images) {
                    ImageDataRes image = new ImageDataRes();
                    image.B64 = item;
                    imageDatas.Add(image);
                }
                res.Results = imageDatas;
            }
            return res;
        }
    }
}
