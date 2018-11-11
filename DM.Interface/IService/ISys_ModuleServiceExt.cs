using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public partial interface ISys_ModuleService
    {
      List<Sys_Module> GetList();
      Sys_Module GetForm(string keyValue);
      void DeleteForm(string keyValue);
      void SubmitForm(Sys_Module moduleEntity, string keyValue);
    }
}
