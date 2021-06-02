using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.Model.ViewModels.Question
{
    public class QuestionDetailsDto
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
        /// 问答数量
        /// </summary>
        public int QuestionCommentCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }


        /// <summary>
        /// 问答推荐
        /// </summary>
        public List<QuestionDto> QuestionList { get; set; }


        /// <summary>
        /// 关联用户
        /// </summary>
        public virtual UserInfoDto UserInfo { get; set; }

        /// <summary>
        /// 问答评论
        /// </summary>
        public virtual List<QuestionCommentDto> QuestionComments { get; set; }
    }
}
