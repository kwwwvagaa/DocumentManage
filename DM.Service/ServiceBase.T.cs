//*******************************************
// 版权所有 黄正辉
// 文件名称：RepositoryBase.T.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:05:10
// 功能描述：仓储实现基类
// 任务编号：档案管理系统
//*******************************************

using DM.Interface.IService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DM.Service
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class,new()
    {
    }
}
