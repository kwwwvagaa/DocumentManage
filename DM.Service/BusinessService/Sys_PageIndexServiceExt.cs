using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Interface.IRepository;

namespace DM.Service.BusinessService
{
    public partial class Sys_PageIndexService
    {
        public override Sys_PageIndex FindEntity(object keyValue)
        {
            Sys_PageIndex entity= base.FindEntity(keyValue);
            entity.LstSys_PageIndexSearchs = DM.Tools.Web.AutofacContainer.Resolve<ISys_PageIndexSearchRepository>().IQueryable(p => p.F_PageIndexF_ID == keyValue).OrderBy(p => p.F_Sort).ToList();
            entity.LstSys_PageIndexTableColumnss = DM.Tools.Web.AutofacContainer.Resolve<ISys_PageIndexTableColumnsRepository>().IQueryable(p => p.F_PageIndexF_ID == keyValue).OrderBy(p => p.F_Sort).ToList();
            entity.LstSys_PageIndexTools = DM.Tools.Web.AutofacContainer.Resolve<ISys_PageIndexToolRepository>().IQueryable(p => p.F_PageIndexF_ID == keyValue).OrderBy(p=>p.F_Sort).ToList();
            return entity;
        }
    }
}
