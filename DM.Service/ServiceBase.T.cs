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
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        public int Insert(TEntity entity)
        {
            return m_iRepository.Insert(entity);
        }

        public int Insert(List<TEntity> entitys)
        {
            return m_iRepository.Insert(entitys);
        }

        public int Update(TEntity entity)
        {
            return m_iRepository.Update(entity);
        }

        public int Delete(TEntity entity)
        {
            return m_iRepository.Delete(entity);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.Delete(predicate);
        }

        public TEntity FindEntity(object keyValue)
        {
            return m_iRepository.FindEntity(keyValue);
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.FindEntity(predicate);
        }

        public IQueryable<TEntity> IQueryable()
        {
            return m_iRepository.IQueryable();
        }

        public IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return m_iRepository.IQueryable(predicate);
        }

        public List<TEntity> FindList(string strSql)
        {
            return m_iRepository.FindList(strSql);
        }

        public List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return m_iRepository.FindList(strSql, dbParameter);
        }

        public List<TEntity> FindList(Tools.Pagination pagination)
        {
            return m_iRepository.FindList(pagination);
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Tools.Pagination pagination)
        {
            return m_iRepository.FindList(predicate, pagination); 
        }
    }
}
