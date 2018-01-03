using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly BlogDb _db;

        public GenericRepository(BlogDb db)
        {
            _db = db;
        }

        public virtual TEntity Get(Guid id)
        {
            return _db.Set<TEntity>().First(x => x.Id == id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().First(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        public virtual bool Exists(Guid id)
        {
            return _db.Set<TEntity>().Any(x => x.Id == id);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Any(predicate);
        }

        public virtual int Count()
        {
            return _db.Set<TEntity>().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Count(predicate);
        }

        public virtual TEntity Create(TEntity entity)
        {
            var createdEntity = _db.Set<TEntity>().Add(entity);

            return createdEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;

            var updatedEntity = Get(entity.Id);

            return updatedEntity;
        }

        public virtual void Delete(Guid id)
        {
            var entityForDelete = _db.Set<TEntity>().Find(id);

            if (entityForDelete == null)
                throw new NullReferenceException();

            _db.Set<TEntity>().Remove(entityForDelete);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}