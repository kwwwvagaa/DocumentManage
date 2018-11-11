using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DM.Interface.IService;
using DM.Domain;

namespace DM.Web.Controllers
{
    public class ClientsDataController : Controller
    {
        ISys_ItemsService m_itemService = null;
        ISys_ItemsDetailService m_itemDetailService = null;
        ISys_OrganizeService m_orgaizeService = null;
        ISys_RoleService m_roleService = null;
        ISys_RoleAuthorizeService m_roleAuthorizeService = null;
        public ClientsDataController(
            ISys_ItemsService itemService,
            ISys_ItemsDetailService itemDetailService,
            ISys_OrganizeService orgaizeService,
            ISys_RoleService roleService,
            ISys_RoleAuthorizeService roleAuthorizeService)
        {
            m_itemService = itemService;
            m_itemDetailService = itemDetailService;
            m_orgaizeService = orgaizeService;
            m_roleService = roleService;
            m_roleAuthorizeService = roleAuthorizeService;
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
            };
            return Content(data.ToJson());
        }
        private object GetDataItemList()
        {
            var lstItemDetails = m_itemDetailService.IQueryable().ToList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            var lstItems = m_itemService.IQueryable().ToList();
            foreach (var item in lstItems)
            {
                var dataItemList = lstItemDetails.FindAll(t => t.F_ItemId.Equals(item.F_Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.F_ItemCode, itemList.F_ItemName);
                }
                dictionaryItem.Add(item.F_EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }
        private object GetOrganizeList()
        {

            var data = m_orgaizeService.IQueryable().ToList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_Organize item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetRoleList()
        {

            var data = m_roleService.IQueryable();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_Role item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {

            var data = m_roleService.GetDutyList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_Role item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetMenuList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(m_roleAuthorizeService.GetMenuList(roleId), "0");
        }
        private string ToMenuJson(List<Sys_Module> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<Sys_Module> entitys = data.FindAll(t => t.F_ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.F_Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = m_roleAuthorizeService.GetButtonList(roleId);
            var dataModuleId = data.Distinct(new ExtList<Sys_ModuleButton>("F_ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Sys_ModuleButton item in dataModuleId)
            {
                var buttonList = data.Where(t => t.F_ModuleId.Equals(item.F_ModuleId));
                dictionary.Add(item.F_ModuleId, buttonList);
            }
            return dictionary;
        }
    }
}