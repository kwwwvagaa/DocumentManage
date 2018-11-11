//------------------------------------------------------------------------------
// <auto-generated>
//     此代码从T4模板生成。
//     黄正辉（623128629@qq.com）
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace DM.Domain
{
    /// <summary>	
    /// 数据表实体类：模块表单 (Sys_ModuleForm)
    /// </summary>
    [Serializable()]
    public partial class Sys_ModuleForm:BaseModel
    {
	   private string _F_Id;
       /// <summary>
       /// 表单主键
       /// </summary>  
       [Key] 
       public string F_Id
	   { 
            get
            {
                BeforeGetProperty("F_Id", _F_Id);
                return _F_Id;
            }
            set
            {
                if(!BeforeSetProperty("F_Id", _F_Id))
                    return;
                _F_Id=value;
                AfterSetProperty("F_Id", _F_Id);
             }
		}
	   private string _F_ModuleId;
       /// <summary>
       /// 模块主键
       /// </summary>  
        
       public string F_ModuleId
	   { 
            get
            {
                BeforeGetProperty("F_ModuleId", _F_ModuleId);
                return _F_ModuleId;
            }
            set
            {
                if(!BeforeSetProperty("F_ModuleId", _F_ModuleId))
                    return;
                _F_ModuleId=value;
                AfterSetProperty("F_ModuleId", _F_ModuleId);
             }
		}
	   private string _F_EnCode;
       /// <summary>
       /// 编码
       /// </summary>  
        
       public string F_EnCode
	   { 
            get
            {
                BeforeGetProperty("F_EnCode", _F_EnCode);
                return _F_EnCode;
            }
            set
            {
                if(!BeforeSetProperty("F_EnCode", _F_EnCode))
                    return;
                _F_EnCode=value;
                AfterSetProperty("F_EnCode", _F_EnCode);
             }
		}
	   private string _F_FullName;
       /// <summary>
       /// 名称
       /// </summary>  
        
       public string F_FullName
	   { 
            get
            {
                BeforeGetProperty("F_FullName", _F_FullName);
                return _F_FullName;
            }
            set
            {
                if(!BeforeSetProperty("F_FullName", _F_FullName))
                    return;
                _F_FullName=value;
                AfterSetProperty("F_FullName", _F_FullName);
             }
		}
	   private string _F_FormJson;
       /// <summary>
       /// 表单控件Json
       /// </summary>  
        
       public string F_FormJson
	   { 
            get
            {
                BeforeGetProperty("F_FormJson", _F_FormJson);
                return _F_FormJson;
            }
            set
            {
                if(!BeforeSetProperty("F_FormJson", _F_FormJson))
                    return;
                _F_FormJson=value;
                AfterSetProperty("F_FormJson", _F_FormJson);
             }
		}
	   private int? _F_SortCode;
       /// <summary>
       /// 排序码
       /// </summary>  
        
       public int? F_SortCode
	   { 
            get
            {
                BeforeGetProperty("F_SortCode", _F_SortCode);
                return _F_SortCode;
            }
            set
            {
                if(!BeforeSetProperty("F_SortCode", _F_SortCode))
                    return;
                _F_SortCode=value;
                AfterSetProperty("F_SortCode", _F_SortCode);
             }
		}
	   private bool? _F_DeleteMark;
       /// <summary>
       /// 删除标志
       /// </summary>  
        
       public bool? F_DeleteMark
	   { 
            get
            {
                BeforeGetProperty("F_DeleteMark", _F_DeleteMark);
                return _F_DeleteMark;
            }
            set
            {
                if(!BeforeSetProperty("F_DeleteMark", _F_DeleteMark))
                    return;
                _F_DeleteMark=value;
                AfterSetProperty("F_DeleteMark", _F_DeleteMark);
             }
		}
	   private bool? _F_EnabledMark;
       /// <summary>
       /// 有效标志
       /// </summary>  
        
       public bool? F_EnabledMark
	   { 
            get
            {
                BeforeGetProperty("F_EnabledMark", _F_EnabledMark);
                return _F_EnabledMark;
            }
            set
            {
                if(!BeforeSetProperty("F_EnabledMark", _F_EnabledMark))
                    return;
                _F_EnabledMark=value;
                AfterSetProperty("F_EnabledMark", _F_EnabledMark);
             }
		}
	   private string _F_Description;
       /// <summary>
       /// 描述
       /// </summary>  
        
       public string F_Description
	   { 
            get
            {
                BeforeGetProperty("F_Description", _F_Description);
                return _F_Description;
            }
            set
            {
                if(!BeforeSetProperty("F_Description", _F_Description))
                    return;
                _F_Description=value;
                AfterSetProperty("F_Description", _F_Description);
             }
		}
	   private DateTime? _F_CreatorTime;
       /// <summary>
       /// 创建时间
       /// </summary>  
        
       public DateTime? F_CreatorTime
	   { 
            get
            {
                BeforeGetProperty("F_CreatorTime", _F_CreatorTime);
                return _F_CreatorTime;
            }
            set
            {
                if(!BeforeSetProperty("F_CreatorTime", _F_CreatorTime))
                    return;
                _F_CreatorTime=value;
                AfterSetProperty("F_CreatorTime", _F_CreatorTime);
             }
		}
	   private string _F_CreatorUserId;
       /// <summary>
       /// 创建用户
       /// </summary>  
        
       public string F_CreatorUserId
	   { 
            get
            {
                BeforeGetProperty("F_CreatorUserId", _F_CreatorUserId);
                return _F_CreatorUserId;
            }
            set
            {
                if(!BeforeSetProperty("F_CreatorUserId", _F_CreatorUserId))
                    return;
                _F_CreatorUserId=value;
                AfterSetProperty("F_CreatorUserId", _F_CreatorUserId);
             }
		}
	   private DateTime? _F_LastModifyTime;
       /// <summary>
       /// 最后修改时间
       /// </summary>  
        
       public DateTime? F_LastModifyTime
	   { 
            get
            {
                BeforeGetProperty("F_LastModifyTime", _F_LastModifyTime);
                return _F_LastModifyTime;
            }
            set
            {
                if(!BeforeSetProperty("F_LastModifyTime", _F_LastModifyTime))
                    return;
                _F_LastModifyTime=value;
                AfterSetProperty("F_LastModifyTime", _F_LastModifyTime);
             }
		}
	   private string _F_LastModifyUserId;
       /// <summary>
       /// 最后修改用户
       /// </summary>  
        
       public string F_LastModifyUserId
	   { 
            get
            {
                BeforeGetProperty("F_LastModifyUserId", _F_LastModifyUserId);
                return _F_LastModifyUserId;
            }
            set
            {
                if(!BeforeSetProperty("F_LastModifyUserId", _F_LastModifyUserId))
                    return;
                _F_LastModifyUserId=value;
                AfterSetProperty("F_LastModifyUserId", _F_LastModifyUserId);
             }
		}
	   private DateTime? _F_DeleteTime;
       /// <summary>
       /// 删除时间
       /// </summary>  
        
       public DateTime? F_DeleteTime
	   { 
            get
            {
                BeforeGetProperty("F_DeleteTime", _F_DeleteTime);
                return _F_DeleteTime;
            }
            set
            {
                if(!BeforeSetProperty("F_DeleteTime", _F_DeleteTime))
                    return;
                _F_DeleteTime=value;
                AfterSetProperty("F_DeleteTime", _F_DeleteTime);
             }
		}
	   private string _F_DeleteUserId;
       /// <summary>
       /// 删除用户
       /// </summary>  
        
       public string F_DeleteUserId
	   { 
            get
            {
                BeforeGetProperty("F_DeleteUserId", _F_DeleteUserId);
                return _F_DeleteUserId;
            }
            set
            {
                if(!BeforeSetProperty("F_DeleteUserId", _F_DeleteUserId))
                    return;
                _F_DeleteUserId=value;
                AfterSetProperty("F_DeleteUserId", _F_DeleteUserId);
             }
		}
    }
}

