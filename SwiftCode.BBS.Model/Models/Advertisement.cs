using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 广告
    /// </summary>
    public class Advertisement : RootEntityTkey<int>
    {
        /// <summary>
        /// 广告图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
