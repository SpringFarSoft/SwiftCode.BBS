using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.Article;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class ArticleComment : RootEntityTkey<int>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }


        /// <summary>
        /// 文章Id
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 文章信息
        /// </summary>
        public virtual Article Article { get; set; }

    }
}
