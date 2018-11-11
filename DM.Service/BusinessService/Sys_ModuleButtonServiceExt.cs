using DM.Domain;
using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Service.BusinessService
{
    public partial class Sys_ModuleButtonService
    {
        public List<Sys_ModuleButton> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<Sys_ModuleButton>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.F_ModuleId == moduleId);
            }
            return m_iRepository.IQueryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public Sys_ModuleButton GetForm(string keyValue)
        {
            return m_iRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (m_iRepository.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                m_iRepository.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(Sys_ModuleButton moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.Modify(keyValue);
                m_iRepository.Update(moduleButtonEntity);
            }
            else
            {
                moduleButtonEntity.Create();
                m_iRepository.Insert(moduleButtonEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<Sys_ModuleButton> entitys = new List<Sys_ModuleButton>();
            foreach (string item in ArrayId)
            {
                Sys_ModuleButton moduleButtonEntity = data.Find(t => t.F_Id == item);
                moduleButtonEntity.F_Id = Common.GuId();
                moduleButtonEntity.F_ModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            m_iRepository.Insert(entitys);
        }
    }
}
