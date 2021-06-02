using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Model.ViewModels.Question;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 问答
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IUserInfoService userInfoService, IMapper mapper)
        {
            _questionService = questionService;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }



        /// <summary>
        /// 分页获取问答列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<QuestionDto>>> GetList(int page, int pageSize)
        {
            var entityList = await _questionService.QueryPage(x => true, x => x.CreateTime, page, pageSize);

            return new MessageModel<List<QuestionDto>>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<List<QuestionDto>>(entityList)
            };
        }

        /// <summary>
        /// 根据Id查询问答
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<QuestionDetailsDto>> Get(int id)
        {
            var entity = (await _questionService.Query(d => d.Id == id)).FirstOrDefault();
            var result = _mapper.Map<QuestionDetailsDto>(entity);
            result.QuestionList = _mapper.Map<List<QuestionDto>>(await _questionService.QueryPage(x => x.Id != id, x => x.QuestionComments.Count, 1, 5));

            entity.Traffic += 1;
            _questionService.Update(entity);

            return new MessageModel<QuestionDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = result
            };
        }

        /// <summary>
        /// 创建问答
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> CreateAsync(CreateQuestionInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);

            var entity = _mapper.Map<Question>(input);
            entity.Traffic = 1;
            entity.CreateTime = DateTime.Now;
            entity.CreateUserInfo = await _userInfoService.Get(x => x.Id == token.Uid);
            _questionService.Add(entity);

            return new MessageModel<string>()
            {
                success = true,
                msg = "创建成功"
            };
        }

        /// <summary>
        /// 问答文章
        /// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> UpdateAsync(int id, UpdateQuestionInputDto input)
        {
            var entity = (await _questionService.Query(d => d.Id == id)).FirstOrDefault();

            entity = _mapper.Map(input, entity);

            _questionService.Update(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "修改成功"
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
            var entity = (await _questionService.Query(d => d.Id == id)).FirstOrDefault();
            _questionService.Delete(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除成功"
            };
        }


        /// <summary>
        /// 添加问答评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateQuestionComments")]
        public async Task<MessageModel<string>> CreateQuestionCommentsAsync(int id, CreateQuestionCommentsInputDto input)
        {
            var entity = (await _questionService.Query(d => d.Id == id)).FirstOrDefault();
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            entity.QuestionComments.Add(new QuestionComment()
            {
                Content = input.Content,
                CreateTime = DateTime.Now,
                UserInfo = await _userInfoService.Get(x => x.Id == token.Uid)
            });
            _questionService.Update(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "评论成功"
            };
        }

        /// <summary>
        /// 删除问答评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteQuestionComments")]
        public async Task<MessageModel<string>> DeleteQuestionCommentsAsync(int questionId, int id)
        {
            var entity = (await _questionService.Query(d => d.Id == questionId)).FirstOrDefault();
            entity.QuestionComments.Remove(entity.QuestionComments.FirstOrDefault(x => x.Id == id));
            _questionService.Update(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除评论成功"
            };
        }


    }
}
