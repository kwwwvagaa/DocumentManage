//*******************************************
// 版权所有 黄正辉
// 文件名称：RepositoryBase.T.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:05:10
// 功能描述：仓储实现基类
// 任务编号：档案管理系统
//*******************************************

using DM.Interface;
using DM.Interface.IRepository;
using DM.Interface.IService;
using DM.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace DM.Service
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ServiceBase<TEntity> : IServiceBase<TEntity>, IDependency where TEntity : class,new()
    {
        IRepositoryBase<TEntity> m_iRepository = null;
        public ServiceBase()
        {
        }
        public ServiceBase(IRepositoryBase<TEntity> iRepository)
        {
            m_iRepository = iRepository;
        }

        public virtual int Insert(TEntity entity)
        {
            return m_iRepository.Insert(entity);
        }

        public virtual int Insert(List<TEntity> entitys)
        {
            return m_iRepository.Insert(entitys);
        }

        public virtual int Update(TEntity entity)
        {
            return m_iRepository.Update(entity);
        }

        public virtual int Delete(TEntity entity)
        {
            return m_iRepository.Delete(entity);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.Delete(predicate);
        }

        public virtual TEntity FindEntity(object keyValue)
        {
            return m_iRepository.FindEntity(keyValue);
        }

        public virtual TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.FindEntity(predicate);
        }

        public virtual IQueryable<TEntity> IQueryable()
        {
            return m_iRepository.IQueryable();
        }

        public virtual IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.IQueryable(predicate);
        }

        public virtual List<TEntity> FindList(string strSql)
        {
            return m_iRepository.FindList(strSql);
        }

        public virtual List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return m_iRepository.FindList(strSql, dbParameter);
        }

        public virtual List<TEntity> FindList(Tools.Pagination pagination)
        {
            return m_iRepository.FindList(pagination);
        }

        public virtual List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Tools.Pagination pagination)
        {
            return m_iRepository.FindList(predicate, pagination);
        }
        public DataTable QueryTable(string strSql, DbParameter[] dbParameter = null)
        {
            return m_iRepository.QueryTable(strSql, dbParameter);
        }

        public int ExecuteSql(string strSql, DbParameter[] dbParameter = null)
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
                StringBuilder strWhere = new StringBuilder();
                List<DbParameter> lstParas = new List<DbParameter>();
                foreach (var item in searchdata)
                {
                    if (item.Key == "modelid" || string.IsNullOrEmpty(item.Value.ToString()))
                        continue;
                    string _strWhere = string.Empty;
                    List<DbParameter> _lstParas = new List<DbParameter>();
                    ServiceBase.GetColumnWhere(page.LstSys_PageIndexSearchs, item.Key, item.Value, ref _strWhere, ref _lstParas);
                    if (!string.IsNullOrEmpty(_strWhere))
                    {
                        if (strWhere.Length > 0)
                        {
                            strWhere.Append(" and ");
                        }
                        strWhere.Append(_strWhere);
                        lstParas.AddRange(_lstParas);
                    }

                    strWhere.Append(item.Key).Append(item.Value);
                }
                if (string.IsNullOrEmpty(pagination.sidx))
                {
                    var key = page.LstSys_PageIndexTableColumnss.Find(p => p.F_IsKey == 1);
                    pagination.sidx = key.F_Field;
                }
                string strSql = string.Format("select top{0} {1} from (select {1},row_number() OVER (order by {2}) AS [row_number] from {3} where {4}) as [filter] where [row_number]>{5} order by {2}",
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



    }
}
