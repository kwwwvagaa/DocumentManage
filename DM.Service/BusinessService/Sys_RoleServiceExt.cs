using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain;
using DM.Tools;

namespace DM.Service.BusinessService
{
    public partial class Sys_RoleService
    {
        public List<Sys_Role> GetDutyList(string keyword = "")
        {
            var expression = ExtLinq.True<Sys_Role>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.F_Category == 2);
            return m_iRepository.IQueryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public Sys_Role GetDutyForm(string keyValue)
        {
            return m_iRepository.FindEntity(keyValue);
        }
        public void DeleteDutyForm(string keyValue)
        {
            m_iRepository.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitDutyForm(Sys_Role roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                m_iRepository.Update(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.F_Category = 2;
                m_iRepository.Insert(roleEntity);
            }
        }
    }
}
