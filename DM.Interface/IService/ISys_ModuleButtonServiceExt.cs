using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public partial interface ISys_ModuleButtonService
    {
       List<Sys_ModuleButton> GetList(string moduleId = "");
       Sys_ModuleButton GetForm(string keyValue);
       void DeleteForm(string keyValue);
       void SubmitForm(Sys_ModuleButton moduleButtonEntity, string keyValue);
       void SubmitCloneButton(string moduleId, string Ids);
    }
}
