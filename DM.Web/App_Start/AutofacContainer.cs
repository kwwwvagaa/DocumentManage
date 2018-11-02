using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DM.Web.App_Start
{
    public class AutofacContainer
    {
        private static IContainer m_container;
        public static void Init()
        {
            //第一步： 构造一个AutoFac的builder容器  
            ContainerBuilder builder = new ContainerBuilder();
            #region 加载Repository
            // 加载数据仓储层的程序集。  
            Assembly dalAss = Assembly.Load("DM.Repository");  
            Type[] dalTypes = dalAss.GetTypes();
           
            builder.RegisterTypes(dalTypes).AsImplementedInterfaces(); 
            #endregion

            #region 加载Services
            // 加载业务逻辑层的程序集。  
            Assembly bllAss = Assembly.Load("DM.Service");
            builder.RegisterAssemblyTypes(bllAss).Where(t => typeof(DM.Interface.IDependency).IsAssignableFrom(t));

            #endregion

            Assembly webSystem = Assembly.Load("DM.Web");
            builder.RegisterControllers(webSystem).PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            m_container = container;
        }

        /// <summary>
        /// 功能描述:生成一个对象
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-02 22:14:27
        /// 任务编号:档案管理系统
        /// </summary>
        /// <returns>返回值</returns>
        public static T Resolve<T>()
        {
            var resolveEntity = m_container.Resolve<T>();
            return resolveEntity;
        }
    }
}
