using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Interface.IRepository;
using DM.Interface.IService;
using DM.Tools;

namespace DM.Service.BusinessService
{
    public partial class Sys_RoleAuthorizeService
    {
        ISys_ModuleService m_moduleService = null;
        ISys_ModuleButtonService m_moduleButtonService = null;

        public Sys_RoleAuthorizeService(ISys_RoleAuthorizeRepository iRepository, ISys_ModuleService moduleService, ISys_ModuleButtonService moduleButtonService)
            : base(iRepository)  //IOC注入Repository
        {
            m_iRepository = iRepository;
            m_moduleService = moduleService;
            m_moduleButtonService = moduleButtonService;
        }
        public List<Sys_RoleAuthorize> GetList(string ObjectId)
        {
            return m_iRepository.IQueryable(t => t.F_ObjectId == ObjectId).ToList();
        }
        public List<Sys_Module> GetMenuList(string roleId)
        {
            var data = new List<Sys_Module>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = m_moduleService.GetList();
            }
            else
            {
                var moduledata = m_moduleService.GetList();
                var authorizedata = m_iRepository.IQueryable(t => t.F_ObjectId == roleId && t.F_ItemType == 1).ToList();
                foreach (var item in authorizedata)
                {
                    Sys_Module moduleEntity = moduledata.Find(t => t.F_Id == item.F_ItemId);
                    if (moduleEntity != null)
                    {
                        data.Add(moduleEntity);
                    }
                }
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }
        public List<Sys_ModuleButton> GetButtonList(string roleId)
        {
            var data = new List<Sys_ModuleButton>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = m_moduleButtonService.GetList();
            }
            else
            {
                var buttondata = m_moduleButtonService.GetList();
                var authorizedata = m_iRepository.IQueryable(t => t.F_ObjectId == roleId && t.F_ItemType == 2).ToList();
                foreach (var item in authorizedata)
                {
                    Sys_ModuleButton moduleButtonEntity = buttondata.Find(t => t.F_Id == item.F_ItemId);
                    if (moduleButtonEntity != null)
                    {
                        data.Add(moduleButtonEntity);
                    }
                }
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List< AuthorizeActionModel>();
            var cachedata = CacheFactory.Cache().GetCache<List<AuthorizeActionModel>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata =m_moduleService .GetList();
                var buttondata =m_moduleButtonService .GetList();
                var authorizedata =m_iRepository .IQueryable(t => t.F_ObjectId == roleId).ToList();
                foreach (var item in authorizedata)
                {
                    if (item.F_ItemType == 1)
                    {
                        Sys_Module moduleEntity = moduledata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleEntity.F_Id, F_UrlAddress = moduleEntity.F_UrlAddress });
                    }
                    else if (item.F_ItemType == 2)
                    {
                        Sys_ModuleButton moduleButtonEntity = buttondata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleButtonEntity.F_ModuleId, F_UrlAddress = moduleButtonEntity.F_UrlAddress });
                    }
                }
                CacheFactory.Cache().WriteCache(authorizeurldata, "authorizeurldata_" + roleId, DateTime.Now.AddMinutes(5));
            }
            else
            {
                authorizeurldata = cachedata;
            }
            authorizeurldata = authorizeurldata.FindAll(t => t.F_Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    string[] url = item.F_UrlAddress.Split('?');
                    if (item.F_Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
