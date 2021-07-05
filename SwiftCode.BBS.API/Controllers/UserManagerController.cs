using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using SwiftCode.BBS.Model.ViewModels.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 用户后台管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserManagerController : ControllerBase
    {
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public UserManagerController(IBaseServices<UserInfo> userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }
        /// <summary>
        /// 后台管理分页获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<UserManagerDto>>> GetAsync( [FromQuery] int intPageIndex = 0, int intPageSize = 20)
        {
            var entities= await _userInfoService.GetPagedListAsync(intPageIndex, intPageSize, nameof(UserInfo.CreateTime));
            var response = _mapper.Map<List<UserManagerDto>>(entities);
            return new MessageModel<List<UserManagerDto>>()
            {
                success = true,
                msg = "获取成功",
                response = response
            };
        }
        /// <summary>
        /// 后台管理修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel<string>> UpdateAsync(int id, UserManagerDto input)
        {
            var entity = await _userInfoService.GetAsync(x=>x.Id==id);
            entity = _mapper.Map(input, entity);
            await _userInfoService.UpdateAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "修改成功",
            };
        }
        /// <summary>
        /// 后台管理删除用户信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> DeleteAsync(int id)
        {
            var entity = await _userInfoService.GetAsync(x => x.Id == id);
            await _userInfoService.DeleteAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除成功",
            };
        }
    }
}
