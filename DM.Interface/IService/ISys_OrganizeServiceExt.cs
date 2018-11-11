using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public partial interface ISys_OrganizeService
    {
        List<Sys_Organize> GetList();
        Sys_Organize GetForm(string keyValue);
        void DeleteForm(string keyValue);
        void SubmitForm(Sys_Organize organizeEntity, string keyValue);
    }
}
