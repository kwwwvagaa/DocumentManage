using DM.Domain;
using DM.Interface.IRepository;
using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Service.BusinessService
{
    public partial class Sys_UserService
    {
        ISys_UserLogOnRepository m_iLogRepository;
        public Sys_UserService(ISys_UserRepository iRepository, ISys_UserLogOnRepository iLogRepository)
            : base(iRepository)  //IOC注入Repository
        {
            m_iRepository = iRepository;
            m_iLogRepository = iLogRepository;
        }
        public Sys_User CheckLogin(string username, string password)
        {
            Sys_User userEntity = m_iRepository.FindEntity(t => t.F_Account == username);
            if (userEntity != null)
            {
                if (userEntity.F_EnabledMark == true)
                {
                    Sys_UserLogOn userLogOnEntity = m_iLogRepository.FindEntity(userEntity.F_Id);
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(password.ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    if (dbPassword == userLogOnEntity.F_UserPassword)
                    {
                        DateTime lastVisitTime = DateTime.Now;
                        int LogOnCount = (userLogOnEntity.F_LogOnCount).ToInt() + 1;
                        if (userLogOnEntity.F_LastVisitTime != null)
                        {
                            userLogOnEntity.F_PreviousVisitTime = userLogOnEntity.F_LastVisitTime.ToDate();
                        }
                        userLogOnEntity.F_LastVisitTime = lastVisitTime;
                        userLogOnEntity.F_LogOnCount = LogOnCount;
                        m_iLogRepository.Update(userLogOnEntity);
                        return userEntity;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
