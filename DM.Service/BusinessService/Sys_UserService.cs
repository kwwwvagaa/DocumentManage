using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Interface.IService;
using DM.Interface.IRepository;

namespace DM.Service.BusinessService
{
    public class Sys_UserService : ServiceBase<Sys_User>, ISys_UserService, DM.Interface.IDependency
    {
        private readonly ISys_UserRepository m_repository;
        public Sys_UserService(ISys_UserRepository rerepository)
        {
            m_repository = rerepository;
        }

        public string Test()
        {           
            return m_repository.Test();
        }
    }
}
