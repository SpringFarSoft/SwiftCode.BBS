﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article: RootEntityTkey<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
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
        /// 创建用户信息
        /// </summary>
        public virtual UserInfo CreateUserInfo { get; set; }
        /// <summary>
        /// 收藏文章的用户
        /// </summary>
        public virtual List<UserCollectionArticle> CollectionArticles { get; set; }
        /// <summary>
        /// 文章评论
        /// </summary>
        public virtual List<ArticleComment> ArticleComments { get; set; }

    }
}
