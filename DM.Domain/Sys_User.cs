using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    /// <summary>	
    /// 数据表实体类：用户表 (Sys_User)
    /// </summary>
    [Serializable()]
    public class Sys_User
    {
	   private int _ID;
       /// <summary>
       /// ID
       /// </summary>  
       [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID
	   { 
            get{return _ID;}
            set{ _ID=value;}
		}
	   private string _Account;
       /// <summary>
       /// Account
       /// </summary>  
        
       public string Account
	   { 
            get{return _Account;}
            set{ _Account=value;}
		}
	   private string _Password;
       /// <summary>
       /// Password
       /// </summary>  
        
       public string Password
	   { 
            get{return _Password;}
            set{ _Password=value;}
		}
	   private string _UserName;
       /// <summary>
       /// UserName
       /// </summary>  
        
       public string UserName
	   { 
            get{return _UserName;}
            set{ _UserName=value;}
		}
	   private decimal _age;
       /// <summary>
       /// age
       /// </summary>  
        
       public decimal age
	   { 
            get{return _age;}
            set{ _age=value;}
		}
	   private string _address;
       /// <summary>
       /// ttttt
       /// </summary>  
        
       public string address
	   { 
            get{return _address;}
            set{ _address=value;}
		}
    }
}

