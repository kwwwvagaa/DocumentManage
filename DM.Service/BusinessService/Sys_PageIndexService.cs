//------------------------------------------------------------------------------
// <auto-generated>
//     此代码从T4模板生成。
//     黄正辉（623128629@qq.com）
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Common;
using DM.Domain;
using DM.Tools;
using DM.Interface;
using DM.Interface.IService;
using DM.Interface.IRepository;

namespace DM.Service.BusinessService
{
    /// <summary>
    /// 业务实现：模板夜主页 (Sys_PageIndex)
    /// </summary>
    public partial class Sys_PageIndexService :ServiceBase<Sys_PageIndex>,  ISys_PageIndexService,IDependency
    {
       ISys_PageIndexRepository m_iRepository=null;
       public Sys_PageIndexService(ISys_PageIndexRepository iRepository)
            : base(iRepository)  //IOC注入Repository
       {
            m_iRepository=iRepository;
       }
        
    }
}
