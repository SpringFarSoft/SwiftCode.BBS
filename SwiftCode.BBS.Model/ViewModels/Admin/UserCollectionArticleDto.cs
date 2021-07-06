using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Admin
{
    public class UserCollectionArticleDto : RootEntityTkey<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string CollectionUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateUser { get; set; }
    }
}
