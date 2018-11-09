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
