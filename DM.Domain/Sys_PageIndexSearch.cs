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
    /// 数据表实体类：搜索栏设置 (Sys_PageIndexSearch)
    /// </summary>
    [Serializable()]
    public partial class Sys_PageIndexSearch:BaseModel
    {
	   private string _F_ID;
       /// <summary>
       /// F_ID
       /// </summary>  
       [Key] 
       public string F_ID
	   { 
            get
            {
                BeforeGetProperty("F_ID", _F_ID);
                return _F_ID;
            }
            set
            {
                if(!BeforeSetProperty("F_ID", _F_ID))
                    return;
                _F_ID=value;
                AfterSetProperty("F_ID", _F_ID);
             }
		}
	   private string _F_PageIndexF_ID;
       /// <summary>
       /// 表头ID
       /// </summary>  
        
       public string F_PageIndexF_ID
	   { 
            get
            {
                BeforeGetProperty("F_PageIndexF_ID", _F_PageIndexF_ID);
                return _F_PageIndexF_ID;
            }
            set
            {
                if(!BeforeSetProperty("F_PageIndexF_ID", _F_PageIndexF_ID))
                    return;
                _F_PageIndexF_ID=value;
                AfterSetProperty("F_PageIndexF_ID", _F_PageIndexF_ID);
             }
		}
	   private string _F_Type;
       /// <summary>
       /// 控件类型
       /// </summary>  
        
       public string F_Type
	   { 
            get
            {
                BeforeGetProperty("F_Type", _F_Type);
                return _F_Type;
            }
            set
            {
                if(!BeforeSetProperty("F_Type", _F_Type))
                    return;
                _F_Type=value;
                AfterSetProperty("F_Type", _F_Type);
             }
		}
	   private string _F_Field;
       /// <summary>
       /// 绑定字段
       /// </summary>  
        
       public string F_Field
	   { 
            get
            {
                BeforeGetProperty("F_Field", _F_Field);
                return _F_Field;
            }
            set
            {
                if(!BeforeSetProperty("F_Field", _F_Field))
                    return;
                _F_Field=value;
                AfterSetProperty("F_Field", _F_Field);
             }
		}
	   private string _F_Width;
       /// <summary>
       /// 所占行比例
       /// </summary>  
        
       public string F_Width
	   { 
            get
            {
                BeforeGetProperty("F_Width", _F_Width);
                return _F_Width;
            }
            set
            {
                if(!BeforeSetProperty("F_Width", _F_Width))
                    return;
                _F_Width=value;
                AfterSetProperty("F_Width", _F_Width);
             }
		}
	   private string _F_Text;
       /// <summary>
       /// 标题文字
       /// </summary>  
        
       public string F_Text
	   { 
            get
            {
                BeforeGetProperty("F_Text", _F_Text);
                return _F_Text;
            }
            set
            {
                if(!BeforeSetProperty("F_Text", _F_Text))
                    return;
                _F_Text=value;
                AfterSetProperty("F_Text", _F_Text);
             }
		}
	   private string _F_PromptText;
       /// <summary>
       /// 水印文字
       /// </summary>  
        
       public string F_PromptText
	   { 
            get
            {
                BeforeGetProperty("F_PromptText", _F_PromptText);
                return _F_PromptText;
            }
            set
            {
                if(!BeforeSetProperty("F_PromptText", _F_PromptText))
                    return;
                _F_PromptText=value;
                AfterSetProperty("F_PromptText", _F_PromptText);
             }
		}
	   private int? _F_MustInput;
       /// <summary>
       /// 是否必填
       /// </summary>  
        
       public int? F_MustInput
	   { 
            get
            {
                BeforeGetProperty("F_MustInput", _F_MustInput);
                return _F_MustInput;
            }
            set
            {
                if(!BeforeSetProperty("F_MustInput", _F_MustInput))
                    return;
                _F_MustInput=value;
                AfterSetProperty("F_MustInput", _F_MustInput);
             }
		}
	   private string _F_VerificationType;
       /// <summary>
       /// 验证
       /// </summary>  
        
       public string F_VerificationType
	   { 
            get
            {
                BeforeGetProperty("F_VerificationType", _F_VerificationType);
                return _F_VerificationType;
            }
            set
            {
                if(!BeforeSetProperty("F_VerificationType", _F_VerificationType))
                    return;
                _F_VerificationType=value;
                AfterSetProperty("F_VerificationType", _F_VerificationType);
             }
		}
	   private string _F_VerificationRegex;
       /// <summary>
       /// 验证正则表达式
       /// </summary>  
        
       public string F_VerificationRegex
	   { 
            get
            {
                BeforeGetProperty("F_VerificationRegex", _F_VerificationRegex);
                return _F_VerificationRegex;
            }
            set
            {
                if(!BeforeSetProperty("F_VerificationRegex", _F_VerificationRegex))
                    return;
                _F_VerificationRegex=value;
                AfterSetProperty("F_VerificationRegex", _F_VerificationRegex);
             }
		}
	   private int _F_MaxLength;
       /// <summary>
       /// 输入内容最大长度
       /// </summary>  
        
       public int F_MaxLength
	   { 
            get
            {
                BeforeGetProperty("F_MaxLength", _F_MaxLength);
                return _F_MaxLength;
            }
            set
            {
                if(!BeforeSetProperty("F_MaxLength", _F_MaxLength))
                    return;
                _F_MaxLength=value;
                AfterSetProperty("F_MaxLength", _F_MaxLength);
             }
		}
	   private decimal _F_MinValue;
       /// <summary>
       /// 最小值
       /// </summary>  
        
       public decimal F_MinValue
	   { 
            get
            {
                BeforeGetProperty("F_MinValue", _F_MinValue);
                return _F_MinValue;
            }
            set
            {
                if(!BeforeSetProperty("F_MinValue", _F_MinValue))
                    return;
                _F_MinValue=value;
                AfterSetProperty("F_MinValue", _F_MinValue);
             }
		}
	   private decimal _F_MaxValue;
       /// <summary>
       /// 最大值
       /// </summary>  
        
       public decimal F_MaxValue
	   { 
            get
            {
                BeforeGetProperty("F_MaxValue", _F_MaxValue);
                return _F_MaxValue;
            }
            set
            {
                if(!BeforeSetProperty("F_MaxValue", _F_MaxValue))
                    return;
                _F_MaxValue=value;
                AfterSetProperty("F_MaxValue", _F_MaxValue);
             }
		}
	   private int _F_DecimalLength;
       /// <summary>
       /// 小数位数
       /// </summary>  
        
       public int F_DecimalLength
	   { 
            get
            {
                BeforeGetProperty("F_DecimalLength", _F_DecimalLength);
                return _F_DecimalLength;
            }
            set
            {
                if(!BeforeSetProperty("F_DecimalLength", _F_DecimalLength))
                    return;
                _F_DecimalLength=value;
                AfterSetProperty("F_DecimalLength", _F_DecimalLength);
             }
		}
	   private string _F_VerificationMsg;
       /// <summary>
       /// 验证不通过时提示信息
       /// </summary>  
        
       public string F_VerificationMsg
	   { 
            get
            {
                BeforeGetProperty("F_VerificationMsg", _F_VerificationMsg);
                return _F_VerificationMsg;
            }
            set
            {
                if(!BeforeSetProperty("F_VerificationMsg", _F_VerificationMsg))
                    return;
                _F_VerificationMsg=value;
                AfterSetProperty("F_VerificationMsg", _F_VerificationMsg);
             }
		}
	   private string _F_DefaultValue;
       /// <summary>
       /// 默认值
       /// </summary>  
        
       public string F_DefaultValue
	   { 
            get
            {
                BeforeGetProperty("F_DefaultValue", _F_DefaultValue);
                return _F_DefaultValue;
            }
            set
            {
                if(!BeforeSetProperty("F_DefaultValue", _F_DefaultValue))
                    return;
                _F_DefaultValue=value;
                AfterSetProperty("F_DefaultValue", _F_DefaultValue);
             }
		}
	   private int? _F_Height;
       /// <summary>
       /// 高度
       /// </summary>  
        
       public int? F_Height
	   { 
            get
            {
                BeforeGetProperty("F_Height", _F_Height);
                return _F_Height;
            }
            set
            {
                if(!BeforeSetProperty("F_Height", _F_Height))
                    return;
                _F_Height=value;
                AfterSetProperty("F_Height", _F_Height);
             }
		}
	   private int _F_IsHidden;
       /// <summary>
       /// 是否隐藏
       /// </summary>  
        
       public int F_IsHidden
	   { 
            get
            {
                BeforeGetProperty("F_IsHidden", _F_IsHidden);
                return _F_IsHidden;
            }
            set
            {
                if(!BeforeSetProperty("F_IsHidden", _F_IsHidden))
                    return;
                _F_IsHidden=value;
                AfterSetProperty("F_IsHidden", _F_IsHidden);
             }
		}
	   private string _F_EventBind;
       /// <summary>
       /// 绑定事件JS
       /// </summary>  
        
       public string F_EventBind
	   { 
            get
            {
                BeforeGetProperty("F_EventBind", _F_EventBind);
                return _F_EventBind;
            }
            set
            {
                if(!BeforeSetProperty("F_EventBind", _F_EventBind))
                    return;
                _F_EventBind=value;
                AfterSetProperty("F_EventBind", _F_EventBind);
             }
		}
	   private string _F_SourceType;
       /// <summary>
       /// 数据源类型
       /// </summary>  
        
       public string F_SourceType
	   { 
            get
            {
                BeforeGetProperty("F_SourceType", _F_SourceType);
                return _F_SourceType;
            }
            set
            {
                if(!BeforeSetProperty("F_SourceType", _F_SourceType))
                    return;
                _F_SourceType=value;
                AfterSetProperty("F_SourceType", _F_SourceType);
             }
		}
	   private string _F_Source;
       /// <summary>
       /// 数据源
       /// </summary>  
        
       public string F_Source
	   { 
            get
            {
                BeforeGetProperty("F_Source", _F_Source);
                return _F_Source;
            }
            set
            {
                if(!BeforeSetProperty("F_Source", _F_Source))
                    return;
                _F_Source=value;
                AfterSetProperty("F_Source", _F_Source);
             }
		}
	   private string _F_DisplayField;
       /// <summary>
       /// 显示文字绑定的字段
       /// </summary>  
        
       public string F_DisplayField
	   { 
            get
            {
                BeforeGetProperty("F_DisplayField", _F_DisplayField);
                return _F_DisplayField;
            }
            set
            {
                if(!BeforeSetProperty("F_DisplayField", _F_DisplayField))
                    return;
                _F_DisplayField=value;
                AfterSetProperty("F_DisplayField", _F_DisplayField);
             }
		}
	   private string _F_ValueField;
       /// <summary>
       /// 值绑定字段
       /// </summary>  
        
       public string F_ValueField
	   { 
            get
            {
                BeforeGetProperty("F_ValueField", _F_ValueField);
                return _F_ValueField;
            }
            set
            {
                if(!BeforeSetProperty("F_ValueField", _F_ValueField))
                    return;
                _F_ValueField=value;
                AfterSetProperty("F_ValueField", _F_ValueField);
             }
		}
	   private string _F_DateType;
       /// <summary>
       /// 日期类型
       /// </summary>  
        
       public string F_DateType
	   { 
            get
            {
                BeforeGetProperty("F_DateType", _F_DateType);
                return _F_DateType;
            }
            set
            {
                if(!BeforeSetProperty("F_DateType", _F_DateType))
                    return;
                _F_DateType=value;
                AfterSetProperty("F_DateType", _F_DateType);
             }
		}
	   private string _F_CodingRules;
       /// <summary>
       /// 编码规则
       /// </summary>  
        
       public string F_CodingRules
	   { 
            get
            {
                BeforeGetProperty("F_CodingRules", _F_CodingRules);
                return _F_CodingRules;
            }
            set
            {
                if(!BeforeSetProperty("F_CodingRules", _F_CodingRules))
                    return;
                _F_CodingRules=value;
                AfterSetProperty("F_CodingRules", _F_CodingRules);
             }
		}
	   private string _F_PopupType;
       /// <summary>
       /// 弹出类型
       /// </summary>  
        
       public string F_PopupType
	   { 
            get
            {
                BeforeGetProperty("F_PopupType", _F_PopupType);
                return _F_PopupType;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupType", _F_PopupType))
                    return;
                _F_PopupType=value;
                AfterSetProperty("F_PopupType", _F_PopupType);
             }
		}
	   private string _F_PopupSourceTreeUrl;
       /// <summary>
       /// 左边树数据url
       /// </summary>  
        
       public string F_PopupSourceTreeUrl
	   { 
            get
            {
                BeforeGetProperty("F_PopupSourceTreeUrl", _F_PopupSourceTreeUrl);
                return _F_PopupSourceTreeUrl;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupSourceTreeUrl", _F_PopupSourceTreeUrl))
                    return;
                _F_PopupSourceTreeUrl=value;
                AfterSetProperty("F_PopupSourceTreeUrl", _F_PopupSourceTreeUrl);
             }
		}
	   private string _F_PopupSourceUrl;
       /// <summary>
       /// 表格数据源Url
       /// </summary>  
        
       public string F_PopupSourceUrl
	   { 
            get
            {
                BeforeGetProperty("F_PopupSourceUrl", _F_PopupSourceUrl);
                return _F_PopupSourceUrl;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupSourceUrl", _F_PopupSourceUrl))
                    return;
                _F_PopupSourceUrl=value;
                AfterSetProperty("F_PopupSourceUrl", _F_PopupSourceUrl);
             }
		}
	   private string _F_PopupSlectType;
       /// <summary>
       /// 选择类型
       /// </summary>  
        
       public string F_PopupSlectType
	   { 
            get
            {
                BeforeGetProperty("F_PopupSlectType", _F_PopupSlectType);
                return _F_PopupSlectType;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupSlectType", _F_PopupSlectType))
                    return;
                _F_PopupSlectType=value;
                AfterSetProperty("F_PopupSlectType", _F_PopupSlectType);
             }
		}
	   private string _F_PopupTextField;
       /// <summary>
       /// 返回结果的显示文字字段
       /// </summary>  
        
       public string F_PopupTextField
	   { 
            get
            {
                BeforeGetProperty("F_PopupTextField", _F_PopupTextField);
                return _F_PopupTextField;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupTextField", _F_PopupTextField))
                    return;
                _F_PopupTextField=value;
                AfterSetProperty("F_PopupTextField", _F_PopupTextField);
             }
		}
	   private string _F_PopupValueField;
       /// <summary>
       /// 返回结果的值字段
       /// </summary>  
        
       public string F_PopupValueField
	   { 
            get
            {
                BeforeGetProperty("F_PopupValueField", _F_PopupValueField);
                return _F_PopupValueField;
            }
            set
            {
                if(!BeforeSetProperty("F_PopupValueField", _F_PopupValueField))
                    return;
                _F_PopupValueField=value;
                AfterSetProperty("F_PopupValueField", _F_PopupValueField);
             }
		}
	   private int _F_Sort;
       /// <summary>
       /// 排序
       /// </summary>  
        
       public int F_Sort
	   { 
            get
            {
                BeforeGetProperty("F_Sort", _F_Sort);
                return _F_Sort;
            }
            set
            {
                if(!BeforeSetProperty("F_Sort", _F_Sort))
                    return;
                _F_Sort=value;
                AfterSetProperty("F_Sort", _F_Sort);
             }
		}
	   private string _F_Memo;
       /// <summary>
       /// 描述
       /// </summary>  
        
       public string F_Memo
	   { 
            get
            {
                BeforeGetProperty("F_Memo", _F_Memo);
                return _F_Memo;
            }
            set
            {
                if(!BeforeSetProperty("F_Memo", _F_Memo))
                    return;
                _F_Memo=value;
                AfterSetProperty("F_Memo", _F_Memo);
             }
		}
	   private int _F_Enable;
       /// <summary>
       /// 是否可用
       /// </summary>  
        
       public int F_Enable
	   { 
            get
            {
                BeforeGetProperty("F_Enable", _F_Enable);
                return _F_Enable;
            }
            set
            {
                if(!BeforeSetProperty("F_Enable", _F_Enable))
                    return;
                _F_Enable=value;
                AfterSetProperty("F_Enable", _F_Enable);
             }
		}
	   private string _F_SearchType;
       /// <summary>
       /// 条件运算符
       /// </summary>  
        
       public string F_SearchType
	   { 
            get
            {
                BeforeGetProperty("F_SearchType", _F_SearchType);
                return _F_SearchType;
            }
            set
            {
                if(!BeforeSetProperty("F_SearchType", _F_SearchType))
                    return;
                _F_SearchType=value;
                AfterSetProperty("F_SearchType", _F_SearchType);
             }
		}
	  
	   private Sys_PageIndex _Sys_PageIndex ;    
       [ForeignKey("F_PageIndexF_ID")] 
       public Sys_PageIndex Sys_PageIndex
	   { 
            get
            {
                BeforeGetProperty("Sys_PageIndex",_Sys_PageIndex );
                return _Sys_PageIndex;
            }
            set
            {
                if(!BeforeSetProperty("Sys_PageIndex",_Sys_PageIndex))
                    return;
                _Sys_PageIndex=value;
                AfterSetProperty("Sys_PageIndex",_Sys_PageIndex);
            }
		}
    }
}

