using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Req {
    /// <summary>
    /// SD接口调用
    /// </summary>
    public class SDImgReq {
        /// <summary>
        /// 高度（不适用这个去设置，容易导致图片生成重复的内容，因sd的模型，一般都是基于512去训练的）
        /// </summary>
        public long? height { get; set; } = 512;

        /// <summary>
        /// 宽度（不适用这个去设置，容易导致图片生成重复的内容，因sd的模型，一般都是基于512去训练的）
        /// </summary>
        public long? width { get; set; } = 512;

        /// <summary>
        /// 反向提示词
        /// </summary>
        public string? negative_prompt { get; set; }
        /// <summary>
        /// 正向提示词
        /// </summary>
        public string prompt { get; set; }

        /// <summary>
        /// 面部修复（画人像的时候可以考虑使用）
        /// </summary>
        public bool? restore_faces { get; set; } = false;

        /// <summary>
        /// 总批次数
        /// </summary>  
        public long? n_iter { get; set; } = 1;
        /// <summary>
        /// 单批数量（每次生成的图片数量）
        /// </summary>
        public long? batch_size { get; set; } = 4;
        /// <summary>
        /// Sampler 采样方法，默认Euler
        /// </summary>
        public string sampler_index { get; set; } = "Euler a";
        /// <summary>
        /// 随机种子数，默认为-1
        /// </summary>
        public long? seed { get; set; } = -1;
        /// <summary>
        /// 生成步数，默认20
        /// </summary>
        public long? steps { get; set; } = 20;


        /// <summary>
        /// 平铺
        /// </summary>
        public bool? tiling { get; set; } = false;

        public int? n;
    }
}
