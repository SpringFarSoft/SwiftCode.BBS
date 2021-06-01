using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;

namespace SwiftCode.BBS.Extensions.AutoMapper
{
    public class ArticlePorfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ArticlePorfile()
        {
            CreateMap<CreateArticleInputDto, Article>();
            CreateMap<UpdateArticleInputDto, Article>();
            
            CreateMap<Article, ArticleDto>();
            CreateMap<Article, ArticleDetailsDto>();

            CreateMap<ArticleComment, ArticleCommentDto>();


            CreateMap<CreateArticleCommentsInputDto, ArticleComment>();
        }
    }
}
