using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers.Admin
{
    /// <summary>
    /// 问答管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionManagerController : ControllerBase
    {
        private readonly IQuestionServices _questionService;
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 分页获取问答列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<QuestionDto>>> GetList(int page, int pageSize)
        {
            var entityList = await _questionService.GetPagedListAsync(page, pageSize, nameof(Question.CreateTime));
            return new MessageModel<List<QuestionDto>>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<List<QuestionDto>>(entityList)
            };
        }
        /// <summary>
        /// 删除问答
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> DeleteAsync(int id)
        {
            var entity = await _questionService.GetAsync(d => d.Id == id);
            await _questionService.DeleteAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除成功"
            };
        }
        /// <summary>
        /// 获取问答评论列表
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<QuestionCommentDto>>> GetQuestionListAsync(int questionId)
        {
            var entity = await _questionService.GetByIdAsync(questionId);

            var list = entity.QuestionComments.Select(x => new QuestionCommentDto
            {
                Id = x.Id,
                CreateTime = x.CreateTime,
                IsAdoption = x.IsAdoption,
                CreateUserId = x.CreateUserId,

            }).ToList();

            var users= await _userInfoService.GetListAsync(x => list.Select(a => a.CreateUserId).Contains(x.Id));
            list.ForEach(x =>
            {
                x.UserName = users.FirstOrDefault(a => a.Id == x.CreateUserId)?.UserName;
            });
            return new MessageModel<List<QuestionCommentDto>>()
            {
                success = true,
                msg = "删除评论成功",
                response = list
            };

        }
        /// <summary>
        /// 删除问答评论
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteQuestionComments")]
        public async Task<MessageModel<string>> DeleteQuestionCommentsAsync(int questionId, int id)
        {
            var entity = await _questionService.GetByIdAsync(questionId);
            entity.QuestionComments.Remove(entity.QuestionComments.FirstOrDefault(x => x.Id == id));
            await _questionService.UpdateAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除评论成功"
            };
        }
    }
}
