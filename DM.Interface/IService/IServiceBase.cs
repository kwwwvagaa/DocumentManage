//*******************************************
// 版权所有 黄正辉
// 文件名称：IRepositoryBase.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:00:58
// 功能描述：服务接口
// 任务编号：档案管理系统
//*******************************************

using DM.Tools;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace DM.Interface.IService
{
    /// <summary>
    /// 功能描述:服务接口
    /// 作　　者:黄正辉
    /// 创建日期:2018-11-02 21:04:21
    /// 任务编号:档案管理系统
    /// </summary>
    public interface IServiceBase : IBase
    {
        string GetTableList(Pagination pagination, Dictionary<string, string> searchdata); 
    }
}
