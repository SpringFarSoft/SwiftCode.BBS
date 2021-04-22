using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Services;

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
  
        /// <summary>
        /// 根据Id查询文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Article>> Get(int id)
        {
            IArticleService advertisementServices = new ArticleService();

            return await advertisementServices.Query(d => d.Id == id);
        }
    }
}
