using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;

namespace SwiftCode.BBS.Extensions.ServiceExtensions
{
    public class AutofacModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.Register(c =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<SwiftCodeBbsContext>();
            //    optionsBuilder.UseSqlServer(@"Server=.; Database=SwiftCodeBbs; Trusted_Connection=True; Connection Timeout=600;MultipleActiveResultSets=true;", b => b
            //        .MigrationsAssembly("SwiftCode.BBS.EntityFramework"));
            //    return optionsBuilder.Options;
            //}).InstancePerLifetimeScope();
            //// 注册 DbContext
            //builder.RegisterType<SwiftCodeBbsContext>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();
            // scan all assemblies in current application domain and resolve them on convention
            //builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //    .AsImplementedInterfaces();

            var basePath = AppContext.BaseDirectory;

            // builder.RegisterType<ArticleService>().As<IArticleService>();

            //var assemblysServices = Assembly.Load("SwiftCode.BBS.Services");//要记得!!!这个注入的是实现类层，不是接口层！不是 IServices
            //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。
            //var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");//模式是 Load(解决方案名)
            //builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();


            var servicesDllFile = Path.Combine(basePath, "SwiftCode.BBS.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "SwiftCode.BBS.Repositories.dll");
            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repositories.dll和Services.dll 丢失。";
                throw new Exception(msg);
            }
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();

            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

        }
    }
}
