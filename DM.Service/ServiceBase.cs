
using DM.Interface;
using DM.Interface.IRepository;
using DM.Interface.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using DM.Tools;
using System.Text;
using DM.Domain;
using System.Data.SqlClient;

namespace DM.Service
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    public class ServiceBase : IServiceBase, IDependency
    {
        IRepositoryBase m_iRepository = null;
        public ServiceBase(IRepositoryBase iRepository)
        {
            m_iRepository = iRepository;
        }

        public virtual int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Insert(entity);
        }

        public virtual int Insert<TEntity>(List<TEntity> entitys) where TEntity : class
        {
            return m_iRepository.Insert(entitys);
        }

        public virtual int Update<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Update(entity);
        }

        public virtual int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Delete(entity);
        }

        public virtual int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.Delete(predicate);
        }

        public virtual TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return m_iRepository.FindEntity<TEntity>(keyValue);
        }

        public virtual TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.FindEntity(predicate);
        }

        public virtual IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class
        {
            return m_iRepository.IQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.IQueryable(predicate);
        }

        public virtual List<TEntity> FindList<TEntity>(string strSql) where TEntity : class
        {
            return m_iRepository.FindList<TEntity>(strSql);
        }

        public virtual List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameter) where TEntity : class
        {
            return m_iRepository.FindList<TEntity>(strSql, dbParameter);
        }

        public virtual List<TEntity> FindList<TEntity>(DM.Tools.Pagination pagination) where TEntity : class, new()
        {
            return m_iRepository.FindList<TEntity>(pagination);
        }

        public virtual List<TEntity> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate, DM.Tools.Pagination pagination) where TEntity : class, new()
        {
            return m_iRepository.FindList<TEntity>(predicate, pagination);
        }

        public virtual DataTable QueryTable(string strSql, DbParameter[] dbParameter = null)
        {
            return m_iRepository.QueryTable(strSql, dbParameter);
        }

        public virtual int ExecuteSql(string strSql, DbParameter[] dbParameter = null)
        {
            return m_iRepository.ExecuteSql(strSql, dbParameter);
        }
        public object ExecuteScalar(string strSql, DbParameter[] dbParameter = null)
        {
            return m_iRepository.ExecuteScalar(strSql, dbParameter);
        }
        /// <summary>
        /// 功能描述:获取表格列表
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-10 23:43:58
        /// 任务编号:档案管理系统
        /// </summary>
        /// <param name="pagination">分页信息</param>
        /// <param name="strJson">strJson</param>
        /// <returns>返回值</returns>
        public virtual string GetTableList(Pagination pagination, Dictionary<string, string> searchdata)
        {
            if (searchdata.ContainsKey("modelid"))
            {
                DM.Domain.Sys_PageIndex page = DM.Tools.Web.AutofacContainer.Resolve<ISys_PageIndexService>().FindEntity(searchdata["modelid"]);
                string strTable = page.F_BindTable;

                StringBuilder strSelectColumns = new StringBuilder();
                if (page.LstSys_PageIndexTableColumnss == null || page.LstSys_PageIndexTableColumnss.Count <= 0)
                {
                    throw new Exception("没有要查询的列。");
                }
                foreach (var item in page.LstSys_PageIndexTableColumnss)
                {
                    if (strSelectColumns.Length > 0)
                        strSelectColumns.Append(",");
                    strSelectColumns.Append("[" + item.F_Field + "]");
                }
                StringBuilder strWhere = new StringBuilder("1=1");
                List<DbParameter> lstParas = new List<DbParameter>();
                foreach (var item in searchdata)
                {
                    if (item.Key == "modelid" || string.IsNullOrEmpty(item.Value.ToString()))
                        continue;
                    string _strWhere = string.Empty;
                    List<DbParameter> _lstParas = new List<DbParameter>();
                    GetColumnWhere(page.LstSys_PageIndexSearchs, item.Key, item.Value, ref _strWhere, ref _lstParas);
                    if (!string.IsNullOrEmpty(_strWhere))
                    {
                        if (strWhere.Length > 0)
                        {
                            strWhere.Append(" and ");
                        }
                        strWhere.Append(_strWhere);
                        lstParas.AddRange(_lstParas);
                    }

                    //strWhere.Append(item.Key).Append(item.Value);
                }
                if (string.IsNullOrEmpty(pagination.sidx))
                {
                    var key = page.LstSys_PageIndexTableColumnss.Find(p => p.F_IsKey == 1);
                    pagination.sidx = key.F_Field;
                }
                string strSql = string.Format("select top {0} {1} from (select {1},row_number() OVER (order by {2}) AS [row_number] from {3} where {4}) as [filter] where [row_number]>{5} order by {2}",
                    pagination.rows, strSelectColumns, pagination.sidx, strTable, strWhere, (pagination.page - 1) * pagination.page);
                pagination.records = Convert.ToInt32(ExecuteScalar(string.Format("select count(1) from {0} where {1}", strTable, strWhere), lstParas.ToArray()));
                DataTable dt = QueryTable(strSql, lstParas.ToArray());
                var data = new
                {
                    rows = dt,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records
                };
                return data.ToJson();
            }
            else
            {
                throw new Exception("不是一个有效的查询。");
            }
        }
        /// <summary>
        /// 获取查询列条件语句
        /// </summary>
        /// <param name="lstSys_PageIndexSearchs"></param>
        /// <param name="strColumnName"></param>
        /// <param name="objValue"></param>
        /// <param name="strWhere"></param>
        /// <param name="lstPameters"></param>
        public static void GetColumnWhere(List<Sys_PageIndexSearch> lstSys_PageIndexSearchs, string strColumnName, object objValue, ref string strWhere, ref List<DbParameter> lstPameters)
        {
            var col = lstSys_PageIndexSearchs.Find(p => p.F_Field.ToLower() == strColumnName.ToLower());
            if (col != null)
            {
                if (col.F_Type == "DateInterval")
                {
                    string strValue = objValue.ToString();
                    var lst = strValue.Split('~');
                    if (!string.IsNullOrWhiteSpace(lst[0]))
                    {
                        strWhere = strColumnName + " >= @" + strColumnName + "0";
                        lstPameters.Add(new SqlParameter("@" + strColumnName + "0", objValue));
                    }
                    if (!string.IsNullOrWhiteSpace(lst[1]))
                    {
                        strWhere += string.IsNullOrEmpty(strWhere) ? "" : (" and " + strColumnName + " <= @" + strColumnName + "1");
                        lstPameters.Add(new SqlParameter("@" + strColumnName + "1", objValue));
                    }
                }
                else
                {
                    if (col.F_SearchType == "in" || col.F_SearchType == "not in")
                    {
                        string[] lst = objValue.ToString().Split('~');
                        string strIn = string.Empty;
                        for (int i = 0; i < lst.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(strIn))
                            {
                                strIn += ",";
                            }
                            strIn += "@" + strColumnName + i;
                            lstPameters.Add(new SqlParameter("@" + strColumnName + i, lst[i]));
                        }
                        strWhere = string.Format(strColumnName + " " + col.F_SearchType + " ({0})", strIn);
                    }
                    else
                    {
                        string strType = col.F_SearchType;
                        object _objValue = objValue;
                        if (strType == "like")
                        {
                            _objValue = "%" + _objValue + "%";
                        }
                        else if (strType == "not like")
                        {
                            _objValue = "%" + _objValue + "%";
                        }
                        else if (strType == "left_like")
                        {
                            strType = "like";
                            _objValue = "%" + _objValue;
                        }
                        else if (strType == "right_like")
                        {
                            strType = "like";
                            _objValue = _objValue + "%";
                        }
                        else if (strType == "left_not_like")
                        {
                            strType = "not like";
                            _objValue = "%" + _objValue;
                        }
                        else if (strType == "right_not_like")
                        {
                            strType = " not like";
                            _objValue = _objValue + "%";
                        }
                        strWhere = strColumnName + " " + strType + " @" + strColumnName;
                        lstPameters.Add(new SqlParameter("@" + strColumnName, _objValue));
                    }
                }
            }
        }

    }
}
