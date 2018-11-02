//*******************************************
// 版权所有 黄正辉
// 文件名称：ISys_UserService.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:47:10
// 功能描述：用户服务接口
// 任务编号：档案管理系统
//*******************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public interface ISys_UserService : IServiceBase<Sys_User>
    {
        string Test();
    }
}
