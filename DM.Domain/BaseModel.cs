using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain
{
    public class BaseModel
    {
        /// <summary>
        /// 功能描述:写入新增属性
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-09 22:47:50
        /// 任务编号:档案管理系统
        /// </summary>
        public void Create()
        {
            Type t = this.GetType();
            var pF_Id = t.GetProperty("F_Id");
            if (pF_Id != null)
            {
                pF_Id.SetValue(this, Common.GuId(),null);
            }

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                var pF_CreatorUserId = t.GetProperty("F_CreatorUserId");
                if (pF_CreatorUserId != null)
                {
                    pF_CreatorUserId.SetValue(this, LoginInfo.UserId, null);
                }
            }
            var pF_CreatorTime = t.GetProperty("F_CreatorTime");
            if (pF_CreatorTime != null)
            {
                pF_CreatorTime.SetValue(this, DateTime.Now, null);
            }
        }
        /// <summary>
        /// 功能描述:写入修改属性
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-09 22:48:02
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="keyValue">keyValue</param>
        public void Modify(string keyValue)
        {
            Type t = this.GetType();
            var pF_Id = t.GetProperty("F_Id");
            if (pF_Id != null)
            {
                pF_Id.SetValue(this, keyValue, null);
            }

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                var pF_LastModifyUserId = t.GetProperty("F_LastModifyUserId");
                if (pF_LastModifyUserId != null)
                {
                    pF_LastModifyUserId.SetValue(this, LoginInfo.UserId, null);
                }
            }

            var pF_LastModifyTime = t.GetProperty("F_LastModifyTime");
            if (pF_LastModifyTime != null)
            {
                pF_LastModifyTime.SetValue(this, DateTime.Now, null);
            }
        }

        /// <summary>
        /// 功能描述:写入删除属性
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-09 22:48:07
        /// 任务编号:档案管理系统
        /// </summary>
        public void Remove()
        {
            Type t = this.GetType();
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                var pF_DeleteUserId = t.GetProperty("F_DeleteUserId");
                if (pF_DeleteUserId != null)
                {
                    pF_DeleteUserId.SetValue(this, LoginInfo.UserId, null);
                }
            }
            var pF_DeleteTime = t.GetProperty("F_DeleteTime");
            if (pF_DeleteTime != null)
            {
                pF_DeleteTime.SetValue(this, DateTime.Now, null);
            }

            var pF_DeleteMark = t.GetProperty("F_DeleteMark");
            if (pF_DeleteMark != null)
            {
                pF_DeleteMark.SetValue(this, true, null);
            }
        }
        /// <summary>
        /// 功能描述:属性Get前
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-04 23:32:19
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strFieldName">strFieldName</param>
        /// <param name="objValue">objValue</param>
        public virtual void BeforeGetProperty(string strFieldName, object objValue)
        {
        }


        /// <summary>
        /// 功能描述:属性Set前
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-04 23:36:49
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strFieldName">strFieldName</param>
        /// <param name="objOldValue">objOldValue</param>
        /// <returns>True继续修改属性，false退出</returns>
        public virtual bool BeforeSetProperty(string strFieldName, object objOldValue)
        {
            return true;
        }

        /// <summary>
        /// 功能描述:属性Set后
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-04 23:32:40
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="strFieldName">strFieldName</param>
        /// <param name="objValue">objValue</param>
        public virtual void AfterSetProperty(string strFieldName, object objValue)
        {
        }

    }
}
