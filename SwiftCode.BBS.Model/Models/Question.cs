using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 问答
    /// </summary>
    public class Question : RootEntityTkey<int>
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
        /// 创建用户
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 问答评论
        /// </summary>
        public virtual List<QuestionComment> QuestionComments { get; set; }

    }
}
