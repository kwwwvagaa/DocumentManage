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
    /// 业务实现：主页表格字段设置 (Sys_PageIndexTableColumns)
    /// </summary>
    public partial class Sys_PageIndexTableColumnsService :ServiceBase<Sys_PageIndexTableColumns>,  ISys_PageIndexTableColumnsService,IDependency
    {
       ISys_PageIndexTableColumnsRepository m_iRepository=null;
       public Sys_PageIndexTableColumnsService(ISys_PageIndexTableColumnsRepository iRepository)
            : base(iRepository)  //IOC注入Repository
       {
            m_iRepository=iRepository;
       }
        
    }
}
