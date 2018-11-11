using DM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Interface.IService
{
    public partial interface ISys_LogService
    {
        void WriteDbLog(Sys_Log logEntity);
    }
}
