using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.T4
{
    public class ModelManager
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private const string CONNECTION_STRING = "Server=.;Initial Catalog=DocumentManage;User ID=sa;Password=123456";
        /// <summary>
        /// 用户信息表名
        /// </summary>
        private const string PERSONINFO_TABLE_NAME = "USERINFO";
        /// <summary>
        /// 根据表名查询表结构信息
        /// </summary>
        private const string SELECT_SCHEMA_BY_TABLE_NAME = @"select d.name as 表名       --如果表名相同就返回空  
     , ddd.value as 表说明      --如果表名相同就返回空  
     , a.colorder                                       as 字段序号
     , a.name                                           as 字段名
     , (case
            when columnproperty(a.id, a.name, 'IsIdentity') = 1 then
                1
            else
                0
        end
       )                                                as 是否自增标识
     , (case
            when
            (
                select count(*)
                from sys.sysobjects --查询主键  
                where (name in
                       (
                           select name
                           from sys.sysindexes
                           where (id = a.id)
                                 and (indid in
                                      (
                                          select indid
                                          from sys.sysindexkeys
                                          where (id = a.id)
                                                and (colid in
                                                     (
                                                         select colid from sys.syscolumns where (id = a.id) and (name = a.name)
                                                     )
                                                    )
                                      )
                                     )
                       )
                      )
                      and (xtype = 'PK')
            ) > 0 then
                1
            else
               0
        end
       )                                                as 主键       --查询主键END  
     , b.name                                           as 数据类型
     , a.length                                         as 占用字节数
     , columnproperty(a.id, a.name, 'PRECISION')        as 长度
     , isnull(columnproperty(a.id, a.name, 'Scale'), 0) as 小数位
     , (case
            when a.isnullable = 1 then
                1
            else
                0
        end
       )                                                as 允许空
     , isnull(e.text, '')                               as 缺省值
     , isnull(g.value, '')                              as 备注
from sys.syscolumns                   a
    left join sys.systypes            b
        on a.xtype = b.xusertype
    inner join sys.sysobjects         d
        on a.id = d.id
           and d.xtype = 'U'
           and d.name <> 'dtproperties'
    left outer join
    (
        select major_id
             , value
        from sys.extended_properties
        where name = 'MS_Description'
              and minor_id = 0
    )                                 as ddd
        on a.id = ddd.major_id
    left join sys.syscomments         e
        on a.cdefault = e.id
    left join sys.extended_properties g
        on a.id = g.major_id
           and a.colid = g.minor_id
where d.name='{0}'
order by a.id
       , a.colorder;";

        private const string TABLE_FK_SQL = @"select
a.name as 约束名,
object_name(b.parent_object_id) as 外键表,
c.name as 外键列,
object_name(b.referenced_object_id) as 主健表,
d.name as 主键列
from sys.foreign_keys A
inner join sys.foreign_key_columns B on A.object_id=b.constraint_object_id
inner join sys.columns C on B.parent_object_id=C.object_id and B.parent_column_id=C.column_id 
inner join sys.columns D on B.referenced_object_id=d.object_id and B.referenced_column_id=D.column_id 
where  object_name(b.parent_object_id)!=object_name(b.referenced_object_id)";

        /// <summary>
        /// 获得数据连接
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnection()
        {
            return new SqlConnection(SqlHelper.sqlConnectionStr);
        }

        /// <summary>
        /// 得到当前用户的所有表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableList()
        {
            string sql = "select table_name from information_schema.tables";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<string> list = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i][0].ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// 得到所有表主外键关系
        /// </summary>
        /// <returns></returns>
        public List<FK> GetFK()
        {
            DataTable dt = SqlHelper.ExecuteDataTable(TABLE_FK_SQL);
            List<FK> lst = new List<FK>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FK fk = new FK()
                {
                    FKName = dt.Rows[i]["约束名"].ToString(),
                    WJ_Table = dt.Rows[i]["外键表"].ToString(),
                    WJ_Field = dt.Rows[i]["外键列"].ToString(),
                    ZJ_Table = dt.Rows[i]["主健表"].ToString(),
                    ZJ_Field = dt.Rows[i]["主键列"].ToString()
                };
                lst.Add(fk);
            }

            return lst;
        }
        /// <summary>
        /// 释放连接
        /// </summary>
        /// <param name="con"></param>
        private void ReleaseConnection(SqlConnection con)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable GetTableSchema(string tableName)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(string.Format(SELECT_SCHEMA_BY_TABLE_NAME, tableName));
            return dt;
        }

        /// <summary>
        /// SQL[不完善,需要的自己改造]
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string TransFromSqlType(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "int": return "int";
                case "bigint": return "Int64";
                case "smallint": return "Int16";
                case "text":
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar": return "string";
                case "varbinary":
                case "image":
                case "binary": return "Byte[]";
                case "tinyint": return "byte";
                case "bit": return "bool";
                case "date":
                case "time":
                case "smalldatetime":
                case "timestamp":
                case "datetime": return "DateTime";
                case "money":
                case "numeric":
                case "smallmoney":
                case "decimal": return "decimal";
                case "float": return "double";
                case "real": return "Single";
                default: return "string";
            }
        }
    }
    public class FK
    {
        public string FKName { get; set; }
        public string WJ_Table { get; set; }
        public string WJ_Field { get; set; }
        public string ZJ_Table { get; set; }
        public string ZJ_Field { get; set; }
    }
}
