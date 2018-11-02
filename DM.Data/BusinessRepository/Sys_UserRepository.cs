//*******************************************
// 版权所有 黄正辉
// 文件名称：Sys_UserRepository.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:32:10
// 功能描述：用户数据仓储
// 任务编号：档案管理系统
//*******************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Interface.IRepository;

namespace DM.Repository.BusinessRepository
{
    /// <summary>
    /// 功能描述:用户数据仓储
    /// 作　　者:黄正辉
    /// 创建日期:2018-11-02 21:33:45
    /// 任务编号:档案管理系统
    /// </summary>
    public class Sys_UserRepository : RepositoryBase<Sys_User>, ISys_UserRepository, DM.Interface.IDependency
    {
        public string Test()
        {
            return "aaa";
        }
    }
}
