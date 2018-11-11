using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public partial interface ISys_RoleAuthorizeService
    {
         List<Sys_RoleAuthorize> GetList(string ObjectId);
         List<Sys_Module> GetMenuList(string roleId);
         List<Sys_ModuleButton> GetButtonList(string roleId);
         bool ActionValidate(string roleId, string moduleId, string action);

    }
}
