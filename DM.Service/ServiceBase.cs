
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

        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Insert(entity);
        }

        public int Insert<TEntity>(List<TEntity> entitys) where TEntity : class
        {
            return m_iRepository.Insert(entitys);
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Update(entity);
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            return m_iRepository.Delete(entity);
        }

        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.Delete(predicate);
        }

        public TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return m_iRepository.FindEntity<TEntity>(keyValue);
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.FindEntity(predicate);
        }

        public IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class
        {
            return m_iRepository.IQueryable<TEntity>();
        }

        public IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return m_iRepository.IQueryable(predicate);
        }

        public List<TEntity> FindList<TEntity>(string strSql) where TEntity : class
        {
            return m_iRepository.FindList<TEntity>(strSql);
        }

        public List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameter) where TEntity : class
        {
            return m_iRepository.FindList<TEntity>(strSql, dbParameter);
        }

        public List<TEntity> FindList<TEntity>(DM.Tools.Pagination pagination) where TEntity : class, new()
        {
            return m_iRepository.FindList<TEntity>(pagination);
        }

        public List<TEntity> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate, DM.Tools.Pagination pagination) where TEntity : class, new()
        {
            return m_iRepository.FindList<TEntity>(predicate, pagination);
        }
    }
}
