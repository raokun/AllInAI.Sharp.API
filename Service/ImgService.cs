using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Service {
    public class ImgService {
        private readonly HttpClient _httpClient;
        private readonly IImageService _imageService;
        public ImgService(AuthOption option, HttpClient? httpClient = null) {

            if (httpClient == null) {
                _httpClient = new HttpClient();
            }
            else {
                _httpClient = httpClient;
            }

            _httpClient.BaseAddress = new Uri(option.BaseUrl);
            switch (option.AIType) {
                case AITypeEnum.Baidu:
                    accessToken = option.Key;
                    _imageService = new BaiduImgService();
                    break;
                case AITypeEnum.SD:
                    _imageService = new SDImgService();
                    break;
                case AITypeEnum.MJ:
                    _imageService = new MJImgService();
                    break;
                case AITypeEnum.OpenAi:
                default:
                    _imageService = new OpenAIImgService();
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {option.Key}");
                    break;
            }

        }

        private string? accessToken;

        public async Task<ImgRes> Txt2Img(Txt2ImgReq req) {
            return await _imageService.Txt2Img(_httpClient, req, accessToken);
        }
    }
}
