//*******************************************
// 版权所有 黄正辉
// 文件名称：IRepositoryBase.T.cs
// 作　　者：黄正辉
// 创建日期：2018-11-02 21:01:34
// 功能描述：服务接口
// 任务编号：档案管理系统
//*******************************************
using DM.Tools;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace DM.Interface.IService
{
    /// <summary>
    /// 服务接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IServiceBase<TEntity> where TEntity : class,new()
    {
        //int Insert(TEntity entity);
        //int Insert(List<TEntity> entitys);
        //int Update(TEntity entity);
        //int Delete(TEntity entity);
        //int Delete(Expression<Func<TEntity, bool>> predicate);
        //TEntity FindEntity(object keyValue);
        //TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> IQueryable();
        //IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        //List<TEntity> FindList(string strSql);
        //List<TEntity> FindList(string strSql, DbParameter[] dbParameter);
        //List<TEntity> FindList(Pagination pagination);
        //List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
