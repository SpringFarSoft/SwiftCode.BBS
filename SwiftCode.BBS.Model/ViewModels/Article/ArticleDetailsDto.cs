using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.Model.ViewModels.Article
{
    public class ArticleDetailsDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }


        /// <summary>
        /// 作者
        /// </summary>
        public UserInfoDto CreateUserInfo { get; set; }

        /// <summary>
        /// 文章推荐
        /// </summary>
        public List<ArticleDto> ArticleList { get; set; }

 
        /// <summary>
        /// 文章评论
        /// </summary>
        public List<ArticleCommentDto> ArticleComments { get; set; }



    }
}
