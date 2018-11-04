using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace DM.Domain
{
    /// <summary>	
    /// 数据表实体类：用户表 (Sys_User)
    /// </summary>
    [Serializable()]
    public class Sys_User:BaseModel
    {
	   private int _ID;
       /// <summary>
       /// ID
       /// </summary>  
       [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID
	   { 
            get{
                    BeforeGetProperty("ID", _ID);
                    return _ID;
                }
            set{
                    if(!BeforeSetProperty("ID", _ID))
                        return;
                     _ID=value;
                    AfterSetProperty("ID", _ID);
                }
		}
	   private string _Account;
       /// <summary>
       /// Account
       /// </summary>  
        
       public string Account
	   { 
            get{
                    BeforeGetProperty("Account", _Account);
                    return _Account;
                }
            set{
                    if(!BeforeSetProperty("Account", _Account))
                        return;
                     _Account=value;
                    AfterSetProperty("Account", _Account);
                }
		}
	   private string _Password;
       /// <summary>
       /// Password
       /// </summary>  
        
       public string Password
	   { 
            get{
                    BeforeGetProperty("Password", _Password);
                    return _Password;
                }
            set{
                    if(!BeforeSetProperty("Password", _Password))
                        return;
                     _Password=value;
                    AfterSetProperty("Password", _Password);
                }
		}
	   private string _UserName;
       /// <summary>
       /// UserName
       /// </summary>  
        
       public string UserName
	   { 
            get{
                    BeforeGetProperty("UserName", _UserName);
                    return _UserName;
                }
            set{
                    if(!BeforeSetProperty("UserName", _UserName))
                        return;
                     _UserName=value;
                    AfterSetProperty("UserName", _UserName);
                }
		}
	   private decimal _age;
       /// <summary>
       /// age
       /// </summary>  
        
       public decimal age
	   { 
            get{
                    BeforeGetProperty("age", _age);
                    return _age;
                }
            set{
                    if(!BeforeSetProperty("age", _age))
                        return;
                     _age=value;
                    AfterSetProperty("age", _age);
                }
		}
	   private string _address;
       /// <summary>
       /// ttttt
       /// </summary>  
        
       public string address
	   { 
            get{
                    BeforeGetProperty("address", _address);
                    return _address;
                }
            set{
                    if(!BeforeSetProperty("address", _address))
                        return;
                     _address=value;
                    AfterSetProperty("address", _address);
                }
		}
	   private List<Sys_Role> _lstSys_Roles = new List<Sys_Role>();     
       public List<Sys_Role> LstSys_Roles
	   { 
            get
            {
                BeforeGetProperty("LstSys_Roles",_lstSys_Roles);
                return _lstSys_Roles;
            }
            set
            { 
                if(!BeforeSetProperty("LstSys_Roles",_lstSys_Roles))
                    return;
                _lstSys_Roles=value;
                AfterSetProperty("LstSys_Roles",_lstSys_Roles);
            }
		}
	   private List<Sys_Test> _lstSys_Tests = new List<Sys_Test>();     
       public List<Sys_Test> LstSys_Tests
	   { 
            get
            {
                BeforeGetProperty("LstSys_Tests",_lstSys_Tests);
                return _lstSys_Tests;
            }
            set
            { 
                if(!BeforeSetProperty("LstSys_Tests",_lstSys_Tests))
                    return;
                _lstSys_Tests=value;
                AfterSetProperty("LstSys_Tests",_lstSys_Tests);
            }
		}
    }
}

