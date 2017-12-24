using System;
using System.Linq;
using System.Linq.Expressions;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : EntityBase
    {
        TEntity Get(Guid id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Guid id);
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(Guid id);
        void Save();
    }
}