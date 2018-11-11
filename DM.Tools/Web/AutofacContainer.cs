using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DM.Tools.Web
{
    public class AutofacContainer
    {
        public static IContainer Container;      

        /// <summary>
        /// 功能描述:生成一个对象
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-02 22:14:27
        /// 任务编号:档案管理系统
        /// </summary>
        /// <returns>返回值</returns>
        public static T Resolve<T>()
        {
            var resolveEntity = Container.Resolve<T>();
            return resolveEntity;
        }

        public static object  Resolve(Type type)
        {
            var resolveEntity = Container.Resolve(type);
            return resolveEntity;
        }
    }
}
