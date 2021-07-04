using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// 问答评论
    /// </summary>
    public class QuestionComment : RootEntityTkey<int>
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
        /// 是否采纳
        /// </summary>
        public bool IsAdoption { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }


        /// <summary>
        /// 问答Id
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// 问答信息
        /// </summary>
        public virtual Question Question { get; set; }
    }
}
