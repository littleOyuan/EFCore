using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRM.EntityFrameworkCore
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected readonly CRMDbContext CRMDbContext;

        protected readonly UnitOfWork UnitOfWork;

        public RepositoryBase(CRMDbContext crmDbContext)
        {
            CRMDbContext = crmDbContext;

            UnitOfWork = new UnitOfWork(CRMDbContext);
        }

        public List<TEntity> GetAll()
        {
            return CRMDbContext.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return CRMDbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(TPrimaryKey id)
        {
            return CRMDbContext.Set<TEntity>().FirstOrDefault(CreateEqualityExpression(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return CRMDbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Insert(TEntity entity)
        {
            CRMDbContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            CRMDbContext.Set<TEntity>().Attach(entity);

            CRMDbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            return Get(entity.Id) != null ? Update(entity) : Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            CRMDbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            CRMDbContext.Set<TEntity>().Remove(Get(id));
        }

        public bool Save()
        {
            return UnitOfWork.Commit();
        }

        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpression(TPrimaryKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(TEntity));

            BinaryExpression lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "Id"), Expression.Constant(id, typeof(TPrimaryKey)));

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    public class RepositoryBase<TEntity> : RepositoryBase<TEntity, int> where TEntity : Entity
    {
        public RepositoryBase(CRMDbContext crmDbContext)
            : base(crmDbContext)
        {
        }
    }
}
