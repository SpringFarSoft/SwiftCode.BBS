using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Extensions.AOP;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Repositories.BASE;
using SwiftCode.BBS.Services;
using SwiftCode.BBS.Services.BASE;

namespace SwiftCode.BBS.Extensions.ServiceExtensions
{
    public class AutofacModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var cacheType = new List<Type>();

            if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<BbsCacheAOP>();
                cacheType.Add(typeof(BbsCacheAOP));
            }

            if (Appsettings.app(new string[] {"AppSettings", "LogAOP", "Enabled"}).ObjToBool())
            {
                builder.RegisterType<BbsLogAOP>();
                cacheType.Add(typeof(BbsLogAOP));
            }


            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseServices<>)).As(typeof(IBaseServices<>)).InstancePerDependency();

            var assemblysServices = Assembly.Load("SwiftCode.BBS.Services");//要记得!!!这个注入的是实现类层，不是接口层！不是 IServices
            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy 对目标类型启用接口拦截。拦截器将被确定，通过在类或接口上截取属性, 或添加 InterceptedBy ()
                .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。;//指定已扫描程序集中的类型注册为提供所有其实现的接口。


            var assemblysRepository = Assembly.Load("SwiftCode.BBS.Repositories");//模式是 Load(解决方案名)
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces();

        }
    }
}
