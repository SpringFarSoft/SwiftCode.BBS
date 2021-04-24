//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using SwiftCode.BBS.Repositories.EfContext;

//namespace SwiftCode.BBS.Extensions.ServiceExtensions
//{
//    public static class EfCoreSetup
//    {
//        public static void AddEfCoreSetup(this IServiceCollection services)
//        {
//            services.AddDbContext<SwiftCodeBbsContext>(d => d.UseSqlServer(@"Server=.; Database=SwiftCodeBbs; Trusted_Connection=True; Connection Timeout=600;MultipleActiveResultSets=true;"));
//        }
//    }
//}
