using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Tools;

namespace DM.Service.BusinessService
{
    public partial class Sys_LogService
    {
        public void WriteDbLog(Sys_Log logEntity)
        {
            logEntity.F_Id = Common.GuId();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_IPAddress = "117.81.192.182";
            logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress);
            logEntity.Create();
            m_iRepository.Insert(logEntity);
        }
    }
}
