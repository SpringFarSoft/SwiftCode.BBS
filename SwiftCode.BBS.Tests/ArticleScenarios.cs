using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwiftCode.BBS.Tests
{
    public class ArticleScenarios
    {
        [Fact]
        public async Task Get_get_articles_by_page_and_response_ok_status_code()
        {
            // Arrange 获取服务
            using var server = await ArticleScenariosBase.GetTestHost().StartAsync();

            // Action 发起接口请求
            var response = await server.GetTestClientWithToken()
                .GetAsync("/api/article/getlist?page=1&pageSize=5");

            // Assert 确保接口状态码是200
            response.EnsureSuccessStatusCode();

            // Assert 接口状态码是401
            //Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
