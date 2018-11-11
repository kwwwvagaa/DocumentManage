using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Tools;

namespace DM.Interface.IService
{
    public partial interface ISys_RoleService
    {
        List<Sys_Role> GetDutyList(string keyword = "");
        Sys_Role GetDutyForm(string keyValue);
        void DeleteDutyForm(string keyValue);

        void SubmitDutyForm(Sys_Role roleEntity, string keyValue);
       
    }
}
