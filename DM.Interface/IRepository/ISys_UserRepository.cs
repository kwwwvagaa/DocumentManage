//*******************************************
// 版权所有 黄正辉
// 文件名称：ISys_UserRepository.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:33:56
// 功能描述：用户数据仓储接口
// 任务编号：档案管理系统
//*******************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IRepository
{
    /// <summary>
    /// 功能描述:用户数据仓储接口
    /// 作　　者:黄正辉
    /// 创建日期:2018-11-02 21:34:02
    /// 任务编号:档案管理系统
    /// </summary>
    public interface ISys_UserRepository : IRepositoryBase<Sys_User>
    {
        string Test();
    }
}
