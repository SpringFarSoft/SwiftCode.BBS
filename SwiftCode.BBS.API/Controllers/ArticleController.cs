using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.IServices;

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleServices;

        public ArticleController(IArticleService articleServices)
        {
            _articleServices = articleServices;
        }
  
        /// <summary>
        /// 根据Id查询文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Article>> Get(int id)
        {
            return await _articleServices.Query(d => d.Id == id);
        }
    }
}
