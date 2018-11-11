using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;

namespace DM.Interface.IService
{
    public partial interface ISys_UserService
    {
        Sys_User CheckLogin(string username, string password);
    }
}
