using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwiftCode.BBS.IServices;
namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatController : ControllerBase
    {
        private readonly ICalculateService _advertisementServices;

        public CalculatController(ICalculateService advertisementServices)
        {
            _advertisementServices = advertisementServices;
        }
        /// <summary>
        /// Sum接口
        /// </summary>
        /// <param name="i">参数i</param>
        /// <param name="j">参数j</param>
        /// <returns></returns>
        [HttpGet]
        public int Get(int i, int j)
        {
            return _advertisementServices.Sum(i, j);
        }
    }
}
