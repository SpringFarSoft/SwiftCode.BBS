using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SwiftCode.BBS.Model.Models;


namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {

        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoService userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<MessageModel<UserInfoDetailsDto>> GetCurrentUserInfo()
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _userInfoService.Get(x => x.Id == token.Uid);

            return new MessageModel<UserInfoDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<UserInfoDetailsDto>(userInfo)
            };
        }

    }
}
