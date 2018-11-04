using Autofac;
using Autofac.Integration.Mvc;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace JoyatAdmin
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            //注册Controller
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);

            var business = ConfigRead.Read("register").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var assemblys = business.Select(b => Assembly.Load(b)).ToArray();
            builder.RegisterAssemblyTypes(assemblys).AsImplementedInterfaces();

            //创建一个Autofac的容器
            var container = builder.Build();
            //将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}