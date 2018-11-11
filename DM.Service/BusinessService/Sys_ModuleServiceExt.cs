using DM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Service.BusinessService
{
    public partial class Sys_ModuleService
    {
        public List<Sys_Module> GetList()
        {
            return m_iRepository .IQueryable().OrderBy(t => t.F_SortCode).ToList();
        }
        public Sys_Module GetForm(string keyValue)
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
        public void SubmitForm(Sys_Module moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                m_iRepository.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();
                m_iRepository.Insert(moduleEntity);
            }
        }
    }
}
